using tabuleiro;

namespace Xadrez
{
	class Peao : Peca
	{
		private PartidaDeXadrez _partida;
		public Peao()
		{
		}

		public Peao(Tabuleiro tabuleiro, Cor cor, PartidaDeXadrez partida) : base(tabuleiro, cor)
		{
			_partida = partida;

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
				pos.TestarValores(Posicao.Linha - 1, Posicao.Coluna);
				if (Tabuleiro.VerificaPosicao(pos) && ValidaMovimento(pos))
					jogadasValidas[pos.Linha, pos.Coluna] = true;

				pos.TestarValores(pos.Linha - 1, pos.Coluna);
				if (Tabuleiro.VerificaPosicao(pos) && ValidaMovimento(pos) && QteMovimentos == 0)
					jogadasValidas[pos.Linha, pos.Coluna] = true;

				pos.TestarValores(Posicao.Linha - 1, Posicao.Coluna - 1);
				if (Tabuleiro.VerificaPosicao(pos) && PodeComer(pos))
					jogadasValidas[pos.Linha, pos.Coluna] = true;

				pos.TestarValores(Posicao.Linha - 1, Posicao.Coluna + 1);
				if (Tabuleiro.VerificaPosicao(pos) && PodeComer(pos))
					jogadasValidas[pos.Linha, pos.Coluna] = true;

				// EN PASSANT
				if (Posicao.Linha == 3)
				{
					Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
					if (Tabuleiro.VerificaPosicao(esquerda) && PodeComer(esquerda) && _partida.JogadaEnPassant == Tabuleiro.GetPeca(esquerda))
					{
						jogadasValidas[esquerda.Linha - 1, esquerda.Coluna] = true;
					}
					Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
					if (Tabuleiro.VerificaPosicao(direita) && PodeComer(direita) && _partida.JogadaEnPassant == Tabuleiro.GetPeca(direita))
					{
						jogadasValidas[direita.Linha - 1, direita.Coluna] = true;
					}
				}


				return jogadasValidas;

			}
			else
			{
				pos.TestarValores(Posicao.Linha + 1, Posicao.Coluna);
				if (Tabuleiro.VerificaPosicao(pos) && ValidaMovimento(pos))
					jogadasValidas[pos.Linha, pos.Coluna] = true;

				pos.TestarValores(pos.Linha + 1, pos.Coluna);
				if (Tabuleiro.VerificaPosicao(pos) && ValidaMovimento(pos) && QteMovimentos == 0)
					jogadasValidas[pos.Linha, pos.Coluna] = true;

				pos.TestarValores(Posicao.Linha + 1, Posicao.Coluna - 1);
				if (Tabuleiro.VerificaPosicao(pos) && PodeComer(pos))
					jogadasValidas[pos.Linha, pos.Coluna] = true;

				pos.TestarValores(Posicao.Linha + 1, Posicao.Coluna + 1);
				if (Tabuleiro.VerificaPosicao(pos) && PodeComer(pos))
					jogadasValidas[pos.Linha, pos.Coluna] = true;

				// EN PASSANT 

				if (Posicao.Linha == 4)
				{
					Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
					if (Tabuleiro.VerificaPosicao(esquerda) && PodeComer(esquerda) && _partida.JogadaEnPassant == Tabuleiro.GetPeca(esquerda))
					{
						jogadasValidas[esquerda.Linha + 1, esquerda.Coluna] = true;
					}
					Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
					if (Tabuleiro.VerificaPosicao(direita) && PodeComer(direita) && _partida.JogadaEnPassant == Tabuleiro.GetPeca(direita))
					{
						jogadasValidas[direita.Linha + 1 , direita.Coluna] = true;
					}
				}
			}
			return jogadasValidas;

		}
		public override string ToString()
		{
			return "P";
		}

	}
}
