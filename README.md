![Markuse asjad logo](mas.png)

# Markuse arvuti asjad (pärand)

See hoidla sisaldab koodi, mis oli kasutusel Markuse arvuti asjad versioonides vahemikus 2018-2024. Spetsiaalselt Windowsi jaoks, ei toimi muudes operatsioonsüsteemides.

## Arendaja skriptid

* _devtoolKillAll.bat - Peatab kõik Markuse arvuti asjade protsessid
* _devtoolRestart.bat - Taaskäivitab kõik Markuse arvuti asjade protsessid
* _devtoolShowBinaries.bat - Kuvab kõik kompileeritud binraarid
* _devtoolUpdateAll.bat - Kopeerib kompileeritud binraarid Markuse asjad kausta

## Lahenduse projektid

* FlashUnlock - Mälupulga lukustus, ei luba arvutit kasutada, kui registreeritud mälupulka pole arvutisse sisestatud
* Interaktiivne töölaud - Projekt ITS, alternatiivne töölaua liides explorer.exe asemel
* JTR - Taasjuurutamise tööriist, kontrollib arvuti olukorda ja võimaldab modifitseerida Markuse arvuti asjade väljaande infot ilma Verifile märgistust rikkumata
* Juurutamise tööriist - Lõpetamata projekt, lõppversiooni jaoks vt "Markuse asjade juurutamise tööriist"
* Markuse arvuti integratsioonitarkvara - Taustateenused ja tegumiriba menüü, mis võimaldab teha Markuse arvuti asjadega seotud tegevusi
* Markuse arvuti juhtpaneel - See rakendus võimaldab konfigureerida Markuse arvuti asju, sh taustapiltide muutmine, MarkuStation konfiguratsioon ja vaadata väljaande infot
* Markuse arvuti kohtvõrk - Eelkäia M.A.I.A. projektile, algselt oli plaan seda projekti kasutada veebiserverina
* Markuse arvuti lukustamissüsteem - Unikaalne lukustamise süsteem, mis asendab Windowsi lukustusekraani ning võimaldab arvuti avada Markuse asjade äpi kaudu (ei sisaldu selles hoidlas)
* Markuse asjade teenus - Lõpetamata projekt, katse luua Windowsi teenus Markuse asjade jaoks
* Markuse asjade varundamistööriist - Võimaldab kloonida kindlad kaustad põhikettalt teisele andmekandjale
* Pidu - Uue aasta vastuvõtja 2.0, Visual Basic
* RootImg - Kuvab teksti "Arvuti juurutamine", kui kasutaja algatab juurutamise Markuse arvuti juhtpaneeli kaudu
* StreamSystem - Testprojekt
* TöölauaMärkmed - Sarnane Sticky Notes rakendusele, aga integreeritud Markuse arvuti asjade süsteemiga
* UpdateMASV - Lõpetamata projekt, planeeritud funktsionaalsuseks oli Markuse arvuti asjade versiooni sünkroniseerimine virtuaalse arvutiga

## Lahenduse avamine

Lahenduse avamiseks kasutage Visual Studio tarkvara. Avage ainult "Markuse asjad.sln" fail, ärge projekte eraldiseisvalt avage!

## Verifile nõuded

Kuna suur osa siinolevatest projektidest kasutab Verifile süsteemi, saab neid rakendusi ainult käivitada Markuse arvutis. See on teadlikult nii disainitud, sest need programmid teevad oletusi erinevate failide paigutuse kohta ning ilma seda järgimata võivad need programmid käituda valesti ja potensiaalselt tekidada andmekadu.

Kui soovite muuta arvuti Markuse arvutiks kõigest hoolimata, on vaja kasutada "Markuse asjade juurutamise tööriist" tarkvara, kuid see loob ainult Verifile 1.0 räsi, kõik programmid, mis kontrollivad Verifile 2.0 terviklikust ei toimi (st suur osa nendest projektidest) ning viimase koodi ei ole selles hoidlas. Verifile 1.0 ühilduvad projektid on saadaval "vf_legacy" harus.