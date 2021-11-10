using tabuleiro;

namespace Xadrez
{
	class Torre : Peca
	{
		public Torre(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
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

			// CIMA
			pos.TestarValores(Posicao.Linha - 1, Posicao.Coluna);
			while (Tabuleiro.VerificaPosicao(pos) && ValidaMovimento(pos)) 
			{
				jogadasValidas[pos.Linha, pos.Coluna] = true;
				if (Tabuleiro.GetPeca(pos) != null && Tabuleiro.GetPeca(pos).Cor != Cor) 
				{
					break;
				}
				pos.Linha--;
			}

			// ABAIXO
			pos.TestarValores(Posicao.Linha + 1, Posicao.Coluna);
			while (Tabuleiro.VerificaPosicao(pos) && ValidaMovimento(pos))
			{
				jogadasValidas[pos.Linha, pos.Coluna] = true;
				if (Tabuleiro.GetPeca(pos) != null && Tabuleiro.GetPeca(pos).Cor != Cor)
				{
					break;
				}
				pos.Linha++;
			}

			// DIREITA
			pos.TestarValores(Posicao.Linha, Posicao.Coluna + 1);
			while (Tabuleiro.VerificaPosicao(pos) && ValidaMovimento(pos))
			{
				jogadasValidas[pos.Linha, pos.Coluna] = true;
				if (Tabuleiro.GetPeca(pos) != null && Tabuleiro.GetPeca(pos).Cor != Cor)
				{
					break;
				}
				pos.Coluna++;
			}

			// ESQUERDA
			pos.TestarValores(Posicao.Linha, Posicao.Coluna - 1);
			while (Tabuleiro.VerificaPosicao(pos) && ValidaMovimento(pos))
			{
				jogadasValidas[pos.Linha, pos.Coluna] = true;
				if (Tabuleiro.GetPeca(pos) != null && Tabuleiro.GetPeca(pos).Cor != Cor)
				{
					break;
				}
				pos.Coluna--;
			}


			return jogadasValidas;
		}


		public override string ToString()
		{
			return "T";
		}
	}
}
