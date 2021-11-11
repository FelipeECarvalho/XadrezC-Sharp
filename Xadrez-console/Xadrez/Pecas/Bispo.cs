using tabuleiro;

namespace Xadrez
{
	class Bispo : Peca
	{
		public Bispo() 
		{
		}

		public Bispo(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
		{
		}
		private bool ValidaMovimento(Posicao pos)
		{
			Peca peca = Tabuleiro.GetPeca(pos);
			return peca == null || peca.Cor != Cor;
		}

		public override bool[,] MovimentosPossiveis()
		{
			bool[,] jogadasValidas = new bool[8, 8];
			Posicao pos = new Posicao(0, 0);

			// NE
			pos.TestarValores(Posicao.Linha - 1, Posicao.Coluna + 1);
			while (Tabuleiro.VerificaPosicao(pos) && ValidaMovimento(pos))
			{
				jogadasValidas[pos.Linha, pos.Coluna] = true;
				if (Tabuleiro.GetPeca(pos) != null && Tabuleiro.GetPeca(pos).Cor != Cor)
				{
					break;
				}
				pos.Linha--;
				pos.Coluna++;
			}

			// SE
			pos.TestarValores(Posicao.Linha + 1, Posicao.Coluna + 1);
			while (Tabuleiro.VerificaPosicao(pos) && ValidaMovimento(pos))
			{
				jogadasValidas[pos.Linha, pos.Coluna] = true;
				if (Tabuleiro.GetPeca(pos) != null && Tabuleiro.GetPeca(pos).Cor != Cor)
				{
					break;
				}
				pos.Linha++;
				pos.Coluna++;
			}

			// SO

			pos.TestarValores(Posicao.Linha + 1, Posicao.Coluna - 1);
			while (Tabuleiro.VerificaPosicao(pos) && ValidaMovimento(pos))
			{
				jogadasValidas[pos.Linha, pos.Coluna] = true;
				if (Tabuleiro.GetPeca(pos) != null && Tabuleiro.GetPeca(pos).Cor != Cor)
				{
					break;
				}
				pos.Linha++;
				pos.Coluna--;
			}

			// NO

			pos.TestarValores(Posicao.Linha - 1, Posicao.Coluna - 1);
			while (Tabuleiro.VerificaPosicao(pos) && ValidaMovimento(pos))
			{
				jogadasValidas[pos.Linha, pos.Coluna] = true;
				if (Tabuleiro.GetPeca(pos) != null && Tabuleiro.GetPeca(pos).Cor != Cor)
				{
					break;
				}
				pos.Linha--;
				pos.Coluna--;
			}

			return jogadasValidas;
		}
		public override string ToString()
		{
			return "B";
		}

	}
}
