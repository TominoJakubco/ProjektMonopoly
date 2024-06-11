Třída MainWindow

Vlastnosti:
•	Player CurrentPlayer: Aktuální hráč na tahu.
•	int PlayerCount: Počet hráčů.
•	Player[] Players: Pole hráčů.
•	Brush[] playerColors: Barvy hráčů.
•	static Spaces[] SpacesArray: Pole políček na hrací desce.
•	static int _pCounter: Počítadlo aktuálního hráče.
•	static PlayerInterface[] PlayerInterfaces: Rozhraní hráčů.
Metody:
•	StartGame(): Zahajuje hru a nastavuje rozhraní pro hráče.
•	SetupBoard(): Nastavuje hrací desku a umisťuje políčka.
•	SetupCurrentPlayer(): Nastavuje aktuálního hráče a aktualizuje jeho rozhraní.
•	DiceClick(object sender, RoutedEventArgs e): Akce po kliknutí na tlačítko hodu kostkou, posunuje hráče po desce.
•	CheckSpace(int space, int roll): Kontroluje stav políčka, na kterém hráč stojí (nákup, platby).
•	ChangePlayerClick(object sender, RoutedEventArgs e): Akce pro změnu hráče po ukončení tahu.
•	BuyBtnClick(object sender, RoutedEventArgs e): Akce pro nákup vlastnosti.
•	SellBtnClick(object sender, RoutedEventArgs e): Akce pro prodej vlastnosti.

Třída Spaces

Vlastnosti:
•	int Number: Pozice políček na desce
•	Rectangle[] PlayerFigures: "Figurky" hráčů
•	bool IsOwnable:	Nastavuje zda se políčko dá nebo nedá zakoupit
•	Player Owner: Vlastník políček, základně null
•	static Street[] StreetsArray: Pole vytvořených ulic
•	static Railroads[] RailroadsArray: Pole vytvořených stanic
•	static Companies[] CompaniesArray: Pole vytvořených Utilities (Až pozdě jsem zjistil jak se jim říká)
Metody:
•	SetupSpace(): Rozhodne zda je políčko ulice, stanice, start atd.
•	SetupPlayers(): Nastaví kde a jak mají být hráči na políčku - liší se podle toho jestli jsou v rohovém políčku a nebo podle toho na které straně desky jsou
•	CheckForPlayers(int playerNumber, int currentPlayerSpace, int currentSpace): Zobrazí hráče pouze na příslušných polích
•	SetupBorder(): Upřímně netuším proč jsem na tohle dělal metodu
•	BuyProperty(Player player): Přidává příslušnému hráči zakoupené políčko
•	Pay(Player player, int roll): Odečítá peníze z hráčova účtu
•	SellProperty(Player player): Smaže vlastníka pozemku a přičte hráči cenu pozemku

Třída Player

Vlastnosti
•	int PlayerID: Používána v metodě CheckForPlayers ze třídy Spaces, určuje hráče na políčku
•	string Name: Jméno hráče - původně jsem ho chtěl udělat nastavitelné, ale nezbyl mi čas
•	Brush Color: Barva hráče: Upřímně zbytečné, původně mělo být taky nastavitelné ale opět nezbyl čas
•	int Space: Pozice hráče na desce
•	int Money: Účet hráče
•	List<Street> OwnedStreets: Ulice které hráč vlastní - původně mely být zobrazeny v PlayerInterface, ale nezbyl čas
•	List<Street> OwnedRails: Stanice které hráč vlastní - původně mely být zobrazeny v PlayerInterface, ale nezbyl čas
•	List<Street> OwnedCompanies: Utilities které hráč vlastní - původně mely být zobrazeny v PlayerInterface, ale nezbyl čas

Třída PlayerInterface

Vlastnosti:
•	Player Player: Z dat hráče vytváří interface
•	string PlayerName: Text jména hráče
•	PlayerMoney: Text peněz hráče
Metody:
•	SetupPlayerInterface(): Nastavuje hodnoty PlayerName a PlayerMoney

Třídy Street, Railroads, Companies, Chance, ComunnityChest, Taxes, Start, VisitingJail, FreeParking, GoToJail

Metody:
•	SetupX(): Hlavní aspekt těchto tříd bylo nastavit jejich zobrazení narůzných stranách desky (dole, nahoře, vpravo, vlevo + rohy)






















