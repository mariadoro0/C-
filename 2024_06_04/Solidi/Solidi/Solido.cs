using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidi
{
    internal abstract class Solido
    {
        private Materiale materiale;

        public Solido(Materiale materiale)
        {
            this.materiale = materiale;
        }

        public abstract double Volume();

        public double Peso()
        {
            return materiale.PesoSpecifico * Volume();
        }


        public override string ToString()
        {
            return 
                $"{materiale.ToString()}"+
                $", Peso: {Peso():#.###} kg"+
                $", Volume: {Volume():#.###} dm^3";
        }
    }
}
