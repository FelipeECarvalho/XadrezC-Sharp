﻿namespace tabuleiro
{
	abstract class Peca
	{
		public Posicao Posicao { get; set; }
		public Cor Cor { get; protected set; }
		public int QteMovimentos { get; protected set; }
		public Tabuleiro Tabuleiro { get; protected set; }


		public Peca()
		{
		}

		protected Peca(Tabuleiro tabuleiro)
		{
			Posicao = null;
			QteMovimentos = 0;
			Tabuleiro = tabuleiro;
		}

		public Peca(Tabuleiro tabuleiro, Cor cor)
		{
			Posicao = null;
			Cor = cor;
			Tabuleiro = tabuleiro;
			QteMovimentos = 0;
		}

		public void IncrementaMovimento() 
		{
			QteMovimentos++;
		}

		public void DecrementaMovimento() 
		{
			QteMovimentos--;
		}

		public abstract bool[,] MovimentosPossiveis();
	}
}
