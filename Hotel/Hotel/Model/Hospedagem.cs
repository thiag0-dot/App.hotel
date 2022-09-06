using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Model
{
    public class Hospedagem
    {
        public int qnt_adultos;
        Suite quarto_escolhido;
        
        public Suite QuartoEscolhido
        {
            get => quarto_escolhido;
            set
            {
                if (value == null)
                    throw new Exception("Por favor, selecione sua acomodação");

                quarto_escolhido = value;
            }
        }
        public int Qntadultos
        {
            get => qnt_adultos;
            set
            {
                if (value == 0)
                    throw new Exception("Por favor, selecione a quantidade de adultos");

                qnt_adultos = value;
            }
        }


        public int qntcriancas { get; set; }
        public DateTime DatacheckIn { get; set; }
        public DateTime datacheckOut { get; set; }

        public int Estadia
        {
            get
            {
                return datacheckOut.Subtract(DatacheckIn).Days;
            }
        }
        public double valortotal
        {
            get => ((Qntadultos * QuartoEscolhido.DiariaAdulto) +
                    (qntcriancas * QuartoEscolhido.DiariaCrianca)
                   ) * Estadia;
        }
    }
}
