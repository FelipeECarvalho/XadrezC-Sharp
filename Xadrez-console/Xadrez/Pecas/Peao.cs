using tabuleiro;

namespace Xadrez
{
	class Peao : Peca
	{
		public Peao()
		{
		}

		public Peao(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
		{

		}
		private bool ValidaMovimento(Posicao pos)
		{
			Peca peca = Tabuleiro.GetPeca(pos);
			return peca == null;
		}

		private bool PodeComer(Posicao pos)
		{
			Peca peca = Tabuleiro.GetPeca(pos);
			if (peca == null)
				return false;
			else
				return peca.Cor != Cor;
		}


		public override bool[,] MovimentosPossiveis()
		{
			bool[,] jogadasValidas = new bool[8, 8];
			Posicao pos = new Posicao(0, 0);
			if (this.Cor == Cor.Branca)
			{
				if (QteMovimentos == 0)
				{
					pos.TestarValores(Posicao.Linha - 1, Posicao.Coluna - 1);
					if (Tabuleiro.VerificaPosicao(pos) && PodeComer(pos))
						jogadasValidas[pos.Linha, pos.Coluna] = true;

					pos.TestarValores(Posicao.Linha - 1, Posicao.Coluna + 1);
					if (Tabuleiro.VerificaPosicao(pos) && PodeComer(pos))
						jogadasValidas[pos.Linha, pos.Coluna] = true;

					pos.TestarValores(Posicao.Linha - 1, Posicao.Coluna);
					if (Tabuleiro.VerificaPosicao(pos) && ValidaMovimento(pos))
						jogadasValidas[pos.Linha, pos.Coluna] = true;

					pos.TestarValores(pos.Linha - 1, pos.Coluna);
					if (Tabuleiro.VerificaPosicao(pos) && ValidaMovimento(pos))
						jogadasValidas[pos.Linha, pos.Coluna] = true;
				}
				else
				{
					pos.TestarValores(Posicao.Linha - 1, Posicao.Coluna);
					if (Tabuleiro.VerificaPosicao(pos) && ValidaMovimento(pos))
						jogadasValidas[pos.Linha, pos.Coluna] = true;

					pos.TestarValores(Posicao.Linha - 1, Posicao.Coluna - 1);
					if (Tabuleiro.VerificaPosicao(pos) && PodeComer(pos))
						jogadasValidas[pos.Linha, pos.Coluna] = true;

					pos.TestarValores(Posicao.Linha - 1, Posicao.Coluna + 1);
					if (Tabuleiro.VerificaPosicao(pos) && PodeComer(pos))
						jogadasValidas[pos.Linha, pos.Coluna] = true;

				}
				return jogadasValidas;
			}
			else 
			{
				if (QteMovimentos == 0)
				{
					pos.TestarValores(Posicao.Linha + 1, Posicao.Coluna - 1);
					if (Tabuleiro.VerificaPosicao(pos) && PodeComer(pos))
						jogadasValidas[pos.Linha, pos.Coluna] = true;

					pos.TestarValores(Posicao.Linha + 1, Posicao.Coluna + 1);
					if (Tabuleiro.VerificaPosicao(pos) && PodeComer(pos))
						jogadasValidas[pos.Linha, pos.Coluna] = true;

					pos.TestarValores(Posicao.Linha + 1, Posicao.Coluna);
					if (Tabuleiro.VerificaPosicao(pos) && ValidaMovimento(pos))
						jogadasValidas[pos.Linha, pos.Coluna] = true;

					pos.TestarValores(pos.Linha + 1, pos.Coluna);
					if (Tabuleiro.VerificaPosicao(pos) && ValidaMovimento(pos))
						jogadasValidas[pos.Linha, pos.Coluna] = true;
				}
				else
				{
					pos.TestarValores(Posicao.Linha + 1, Posicao.Coluna);
					if (Tabuleiro.VerificaPosicao(pos) && ValidaMovimento(pos))
						jogadasValidas[pos.Linha, pos.Coluna] = true;

					pos.TestarValores(Posicao.Linha + 1, Posicao.Coluna - 1);
					if (Tabuleiro.VerificaPosicao(pos) && PodeComer(pos))
						jogadasValidas[pos.Linha, pos.Coluna] = true;

					pos.TestarValores(Posicao.Linha + 1, Posicao.Coluna + 1);
					if (Tabuleiro.VerificaPosicao(pos) && PodeComer(pos))
						jogadasValidas[pos.Linha, pos.Coluna] = true;
				}
				return jogadasValidas;
			}
		}
		public override string ToString()
		{
			return "P";
		}

	}
}
