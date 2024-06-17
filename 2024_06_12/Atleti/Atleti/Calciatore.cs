using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atleti
{
    internal class Calciatore : Atleta, IComparable, ICloneable
    {
        public string Squadra { get; set; }
        public int PartiteGiocate { get; set; }
        public int GoalSegnati { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public int CompareTo(object? obj)
        {
            /*
             * 1 se this.media>obj.media
             * -1 se this.media<obj.media
             * 0 altri casi
             */
            if (obj == null) return 0;
            if (obj == this) return 0;
            if (obj is Calciatore other) {
                if (this.MediaGoalSegnati() > other.MediaGoalSegnati()) return 1;
                else if (this.MediaGoalSegnati() < other.MediaGoalSegnati()) return -1;
            } 
            return 0;

        }

        public double MediaGoalSegnati()
        {
            return (double)GoalSegnati / (double)PartiteGiocate;
        }

        public override string ToString()
        {
            return $"" +base.ToString()+
                $"{nameof(Squadra)}={Squadra}, " +
                $"{nameof(PartiteGiocate)}={PartiteGiocate.ToString()}, " +
                $"{nameof(GoalSegnati)}={GoalSegnati.ToString()}, " +
                $"Media Goal segnati= {MediaGoalSegnati()}";
        }
    }
}
