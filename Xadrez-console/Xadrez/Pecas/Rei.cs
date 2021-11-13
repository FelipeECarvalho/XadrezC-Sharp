using tabuleiro;

namespace Xadrez
{
	class Rei : Peca
	{
		public Rei(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
		{
		}


		private bool ValidaMovimento(Posicao pos)
		{
			Peca peca = Tabuleiro.GetPeca(pos);
			return peca == null || peca.Cor != Cor;
		}


		private bool RoquePequenoVerificaLinha()
		{
			for (int i = Posicao.Coluna + 1; i < Tabuleiro.Colunas - 1; i++)
			{
				if (Cor == Cor.Preta)
				{
					if (Tabuleiro.GetPeca(0, i) != null)
						return false;
				}
				else
				{
					if (Tabuleiro.GetPeca(7, i) != null)
						return false;
				}
			}
			return true;
		}

		private bool RoqueGrandeVerificaLinha() 
		{
			for (int i = Posicao.Coluna - 1; i > 1; i--)
			{
				if (Cor == Cor.Preta)
				{
					if (Tabuleiro.GetPeca(0, i) != null)
						return false;
				}
				else
				{
					if (Tabuleiro.GetPeca(7, i) != null)
						return false;
				}
			}
			return true;

		}

		public bool PodeRoqueGrande()

		{
			if (RoqueGrandeVerificaLinha())
			{
				if (Tabuleiro.GetPeca(7, 0) is Torre && Tabuleiro.GetPeca(7, 0).QteMovimentos == 0)
					return true;
				else if (Tabuleiro.GetPeca(0, 0) is Torre && Tabuleiro.GetPeca(0, 0).QteMovimentos == 0)
					return true;
				return false;

			}
			return false;
		}




		public bool PodeRoquePequeno()
		
		{
			if (RoquePequenoVerificaLinha())
			{
				if (Tabuleiro.GetPeca(7, 7) is Torre && Tabuleiro.GetPeca(7, 7).QteMovimentos == 0)
					return true;
				else if (Tabuleiro.GetPeca(0, 7) is Torre && Tabuleiro.GetPeca(0, 7).QteMovimentos == 0)
					return true;
				return false;

			}
			return false;
		}


		public override bool[,] MovimentosPossiveis()
		{
			bool[,] jogadasValidas = new bool[8, 8];
			Posicao pos = new Posicao(0, 0);

			// ROQUE PEQUENO
			if (Cor == Cor.Preta && PodeRoquePequeno() && QteMovimentos == 0)
				jogadasValidas[0, 7] = true;


			if (Cor == Cor.Branca && PodeRoquePequeno() && QteMovimentos == 0)
				jogadasValidas[7, 7] = true;

			// ROQUE GRANDE
			if (Cor == Cor.Preta && PodeRoqueGrande() && QteMovimentos == 0)
				jogadasValidas[0, 0] = true;


			if (Cor == Cor.Branca && PodeRoqueGrande() && QteMovimentos == 0)
				jogadasValidas[7, 0] = true;


			// Cima
			pos.TestarValores(Posicao.Linha - 1, Posicao.Coluna);
			if (Tabuleiro.VerificaPosicao(pos) && ValidaMovimento(pos))
				jogadasValidas[pos.Linha, pos.Coluna] = true;


			// Baixo
			pos.TestarValores(Posicao.Linha + 1, Posicao.Coluna);
			if (Tabuleiro.VerificaPosicao(pos) && ValidaMovimento(pos))
				jogadasValidas[pos.Linha, pos.Coluna] = true;


			// Direita
			pos.TestarValores(Posicao.Linha, Posicao.Coluna + 1);
			if (Tabuleiro.VerificaPosicao(pos) && ValidaMovimento(pos))
				jogadasValidas[pos.Linha, pos.Coluna] = true;

			// Esquerda
			pos.TestarValores(Posicao.Linha, Posicao.Coluna - 1);
			if (Tabuleiro.VerificaPosicao(pos) && ValidaMovimento(pos))
				jogadasValidas[pos.Linha, pos.Coluna] = true;

			// NE
			pos.TestarValores(Posicao.Linha - 1, Posicao.Coluna + 1);
			if (Tabuleiro.VerificaPosicao(pos) && ValidaMovimento(pos))
				jogadasValidas[pos.Linha, pos.Coluna] = true;

			// SE
			pos.TestarValores(Posicao.Linha + 1, Posicao.Coluna + 1);
			if (Tabuleiro.VerificaPosicao(pos) && ValidaMovimento(pos))
				jogadasValidas[pos.Linha, pos.Coluna] = true;

			// SO
			pos.TestarValores(Posicao.Linha + 1, Posicao.Coluna - 1);
			if (Tabuleiro.VerificaPosicao(pos) && ValidaMovimento(pos))
				jogadasValidas[pos.Linha, pos.Coluna] = true;

			// NO
			pos.TestarValores(Posicao.Linha - 1, Posicao.Coluna - 1);
			if (Tabuleiro.VerificaPosicao(pos) && ValidaMovimento(pos))
				jogadasValidas[pos.Linha, pos.Coluna] = true;

			return jogadasValidas;


		}
		public override string ToString()
		{
			return "R";
		}
	}
}
