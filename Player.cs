using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WPF_monopoly
{
    public class Player
    {
        //public bool IsPlayer { get; private set; }
        //public Brush Color { get; private set; }
        public int PlayerID { get; private set; }
        public string Name { get; set; }
        public Brush Color { get; private set; }
        public int Space { get; set; }
        public int Money { get; set; }
        public List<Street> OwnedStreets; //{ get; set; }
        public List<Railroads> OwnedRails; //{ get; set; }
        public List<Companies> OwnedCompanies; //{ get; set; }
        public List<Street> OwnedJailFreeCards; //{ get; set; }

        public Player(int playerID, string name, Brush color, int space, int money/*, List<Street> ownedStreets, List<Railroads> ownedRails, List<Companies> ownedCompanies, List<Street> ownedJailFreeCards*/)
        {
            //IsPlayer = isPlayer;
            PlayerID = playerID;
            Name = name;
            Color = color;
            Space = space;
            Money = money;
            OwnedStreets = new List<Street>();
            OwnedRails = new List<Railroads>();
            OwnedCompanies = new List<Companies>();
            OwnedJailFreeCards = new List<Street>();
        }
    }
}
