using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DarkRPJobGenerator
{
    public class Job
    {
        public Job()
        {
            Models = new ObservableCollection<string>();
            Weapons = new ObservableCollection<string>();
            CanDemote = true;
            Health = 100;
        }
        public string ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public ObservableCollection<string> Models { get; set; }
        public ObservableCollection<string> Weapons { get; set; }
        public Color Color { get; set; }
        public string Description { get; set; }
        public string Command { get; set; }
        public int Salary { get; set; }
        public int Max { get; set; }
        public bool NeedVote { get; set; }
        public int Admin { get; set; }
        public int Health { get; set; }

        public bool CanDemote { get; set; }
        public bool HasLicense { get; set; }
        public int Armor { get; set; }

        string WeaponsString()
        {
            string Out = "{\n";
            foreach (string weapon in Weapons)
            {
                Out += $"   \"{weapon}\",\n";
            }
            Out += "}";
            return Out;
        }
        string ModelsString()
        {
            switch (Models.Count)
            {
                case 0:
                    return $"model = \"models/player/alyx.mdl\"";
                case 1:
                    return $"model = \"{Models.First()}\"";
                default:
                    string Out = "model = {\n";
                    foreach (string model in Models)
                    {
                        Out += $"   \"{model}\",\n";
                    }
                    Out += "}";
                    return Out;
            }
        }

        string ColorString()
        {
            return $"Color({Color.R}, {Color.G}, {Color.B})";
        }

        public override string ToString()
        {
            return $"TEAM_{ID} = DarkRP.createJob(\"{Name}\", " + "{\n" +
                $"  color = {ColorString()},\n" +
                "   "+ModelsString() + ",\n"+
                $"  description = [[{Description}]],\n"+
                $"  weapons = {WeaponsString()},\n"+
                $"  command = \"{Command}\",\n"+
                $"  max = {Max},\n"+
                $"  salary = {Salary},\n"+
                $"  admin = {Admin},\n"+
                $"  vote = {(NeedVote? "true": "false")},\n"+
                $"  hasLicense = {(HasLicense ? "true" : "false")},\n"+
                $"  canDemote = {(CanDemote ? "true" : "false")},\n"+
                $"  PlayerSpawn = function(ply)"+
                $"  ply:SetHealth({Health})"+
                $"  ply:SetMaxHealth({Health})"+
                $"  ply:SetArmor({Armor})"+
                $"  ply:SetMaxArmor({Armor})"+
                "   end"+
                "})";
        }

    }
}
