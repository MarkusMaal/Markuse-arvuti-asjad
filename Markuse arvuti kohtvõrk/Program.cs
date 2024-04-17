// MIT License - Copyright (c) 2016 Can Güney Aksakalli
// https://aksakalli.github.io/2014/02/24/simple-http-server-with-csparp.html

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;


class Program
{
    public static void Main(string[] args)
    {
        SimpleHTTPServer shtps = new SimpleHTTPServer(@"C:\mas\www", 2014);
    }
}

class SimpleHTTPServer
{
    private readonly string[] _indexFiles = { 
        "index.html", 
        "index.htm", 
        "default.html", 
        "default.htm" 
    };

    private static IDictionary<string, string> _mimeTypeMappings = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase) {
        #region extension to MIME type list
        {".asf", "video/x-ms-asf"},
        {".asx", "video/x-ms-asf"},
        {".avi", "video/x-msvideo"},
        {".bin", "application/octet-stream"},
        {".cco", "application/x-cocoa"},
        {".crt", "application/x-x509-ca-cert"},
        {".css", "text/css"},
        {".deb", "application/octet-stream"},
        {".der", "application/x-x509-ca-cert"},
        {".dll", "application/octet-stream"},
        {".dmg", "application/octet-stream"},
        {".ear", "application/java-archive"},
        {".eot", "application/octet-stream"},
        {".exe", "application/octet-stream"},
        {".flv", "video/x-flv"},
        {".gif", "image/gif"},
        {".hqx", "application/mac-binhex40"},
        {".htc", "text/x-component"},
        {".htm", "text/html"},
        {".html", "text/html"},
        {".ico", "image/x-icon"},
        {".img", "application/octet-stream"},
        {".iso", "application/octet-stream"},
        {".jar", "application/java-archive"},
        {".jardiff", "application/x-java-archive-diff"},
        {".jng", "image/x-jng"},
        {".jnlp", "application/x-java-jnlp-file"},
        {".jpeg", "image/jpeg"},
        {".jpg", "image/jpeg"},
        {".js", "application/x-javascript"},
        {".mml", "text/mathml"},
        {".mng", "video/x-mng"},
        {".mov", "video/quicktime"},
        {".mp3", "audio/mpeg"},
        {".mpeg", "video/mpeg"},
        {".mpg", "video/mpeg"},
        {".msi", "application/octet-stream"},
        {".msm", "application/octet-stream"},
        {".msp", "application/octet-stream"},
        {".pdb", "application/x-pilot"},
        {".pdf", "application/pdf"},
        {".pem", "application/x-x509-ca-cert"},
        {".pl", "application/x-perl"},
        {".pm", "application/x-perl"},
        {".png", "image/png"},
        {".prc", "application/x-pilot"},
        {".ra", "audio/x-realaudio"},
        {".rar", "application/x-rar-compressed"},
        {".rpm", "application/x-redhat-package-manager"},
        {".rss", "text/xml"},
        {".run", "application/x-makeself"},
        {".sea", "application/x-sea"},
        {".shtml", "text/html"},
        {".sit", "application/x-stuffit"},
        {".swf", "application/x-shockwave-flash"},
        {".tcl", "application/x-tcl"},
        {".tk", "application/x-tcl"},
        {".txt", "text/plain"},
        {".war", "application/java-archive"},
        {".wbmp", "image/vnd.wap.wbmp"},
        {".wmv", "video/x-ms-wmv"},
        {".xml", "text/xml"},
        {".xpi", "application/x-xpinstall"},
        {".zip", "application/zip"},
        #endregion
    };
    private Thread _serverThread;
    private string _rootDirectory;
    private HttpListener _listener;
    private int _port;

    public int Port
    {
        get { return _port; }
        private set { }
    }

    /// <summary>
    /// Construct server with given port.
    /// </summary>
    /// <param name="path">Directory path to serve.</param>
    /// <param name="port">Port of the server.</param>
    public SimpleHTTPServer(string path, int port)
    {
        this.Initialize(path, port);
    }

    /// <summary>
    /// Construct server with suitable port.
    /// </summary>
    /// <param name="path">Directory path to serve.</param>
    public SimpleHTTPServer(string path)
    {
        //get an empty port
        TcpListener l = new TcpListener(IPAddress.Loopback, 0);
        l.Start();
        int port = ((IPEndPoint)l.LocalEndpoint).Port;
        l.Stop();
        this.Initialize(path, port);
    }

    /// <summary>
    /// Stop server and dispose all functions.
    /// </summary>
    public void Stop()
    {
        _serverThread.Abort();
        _listener.Stop();
    }

    private void Listen()
    {
        _listener = new HttpListener();
        _listener.Prefixes.Add("http://*:" + _port.ToString() + "/");
        _listener.Start();
        while (true)
        {
            try
            {
                HttpListenerContext context = _listener.GetContext();
                Process(context);
            }
            catch (Exception ex)
            {

            }
        }
    }
    private void WriteString(Stream stream, string stringToWrite, Encoding encoding)
    {
        var charBuffer = encoding.GetBytes(stringToWrite);
        stream.Write(charBuffer, 0, charBuffer.Length);
    }
    private void Process(HttpListenerContext context)
    {
        string filename = context.Request.Url.AbsolutePath;

        Dictionary<string, string> POST = new Dictionary<string, string>();
        Dictionary<string, string> GET = new Dictionary<string, string>();
        if (context.Request.Url.AbsoluteUri.Contains("?"))
        {
            string[] gets = context.Request.Url.Query.Substring(1).Split('&');

            foreach (string get in gets)
            {
                GET.Add(get.Split('=')[0], get.Split('=')[1]);
            }
        }
        if (context.Request.InputStream.Length > 0)
        {
            string sr = new StreamReader(context.Request.InputStream).ReadToEnd();
            if (sr != "")
            {
                string[] body = sr.Split('&');
                foreach (string value in body)
                {
                    string[] variablevalue = value.Split('=');
                    POST.Add(variablevalue[0], variablevalue[1]);
                }
            }
        }
        Console.WriteLine("Processing document: " + filename);
        filename = filename.Substring(1);

        if (string.IsNullOrEmpty(filename))
        {
            foreach (string indexFile in _indexFiles)
            {
                if (File.Exists(Path.Combine(_rootDirectory, indexFile)))
                {
                    filename = indexFile;
                    break;
                }
            }
        }
        filename = this._rootDirectory + "\\" + filename.Replace("/", "\\");
        Console.WriteLine("Processing document: " + filename);
        Stream doc = new FileStream("doc.html", FileMode.Create);
        foreach (byte b in File.ReadAllBytes(this._rootDirectory + "\\head.html"))
        {
            doc.WriteByte(b);
        }
        foreach (byte b in Encoding.UTF8.GetBytes(this.ProcessMe(POST, GET)))
        {
            doc.WriteByte(b);
        }
        foreach (byte b in File.ReadAllBytes(this._rootDirectory + "\\foot.html"))
        {
            doc.WriteByte(b);
        }
        doc.Flush();
        doc.Close();
        Stream input = new FileStream("doc.html", FileMode.Open);
        //Adding permanent http response headers
        string mime;
        context.Response.ContentType = _mimeTypeMappings.TryGetValue(Path.GetExtension(filename), out mime) ? mime : "application/octet-stream";
        context.Response.ContentLength64 = input.Length;
        context.Response.AddHeader("Date", DateTime.Now.ToString("r"));
        context.Response.AddHeader("Last-Modified", System.IO.File.GetLastWriteTime(filename).ToString("r"));

        byte[] buffer = new byte[1024 * 16];
        int nbytes;
        while ((nbytes = input.Read(buffer, 0, buffer.Length)) > 0)
            context.Response.OutputStream.Write(buffer, 0, nbytes);
        input.Close();
        Console.WriteLine("HTTP Statuscode: 200");
        context.Response.StatusCode = (int)HttpStatusCode.OK;
        context.Response.OutputStream.Flush();

        context.Response.OutputStream.Close();
        Console.WriteLine("Connection closed");
        Console.WriteLine("--------------------------------------------------------------------------");
    }

    private void Initialize(string path, int port)
    {
        this._rootDirectory = path;
        this._port = port;
        _serverThread = new Thread(this.Listen);
        _serverThread.Start();
    }

    private string ProcessMe(Dictionary<string, string> POST, Dictionary<string, string> GET)
    {
        try
        {
            if (POST.Count > 0)
            {
                Console.WriteLine("POST");
                foreach (KeyValuePair<string, string> kvp in POST)
                {
                    Console.WriteLine("Key = {0}, Value = {1}",
                        kvp.Key, kvp.Value);
                }
            }
            if (GET.Count > 0)
            {
                Console.WriteLine(GET["act"]);
                foreach (KeyValuePair<string, string> kvp in GET)
                {
                    Console.WriteLine("Key = {0}, Value = {1}",
                        kvp.Key, kvp.Value);
                }
                if (GET["act"] == "markustation")
                {
                    string fn = "C:\\mas\\MarkuStation.exe";
                    using (FileStream fs = new FileStream("C:\\mas\\runfile.log", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    using (StreamWriter fw = new StreamWriter(fs))
                    {
                        fw.Write(fn);
                    }
                    return "<p>Käivitati " + fn + "</p>";
                }
                else if (GET["act"] == "showhideicon")
                {
                    string fn = "C:\\mas\\organize_desktop.bat";
                    using (FileStream fs = new FileStream("C:\\mas\\runfile.log", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    using (StreamWriter fw = new StreamWriter(fs))
                    {
                        fw.Write(fn);
                        fw.Write("\n\n");
                        fw.Write("C:\\mas\n");
                        fw.Write("hidden");
                    }
                    return "<p>Käivitati " + fn + "</p>";
                }
            }
            return "";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }


}