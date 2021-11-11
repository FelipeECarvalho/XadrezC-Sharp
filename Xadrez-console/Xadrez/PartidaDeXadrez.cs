using System;
using System.Collections.Generic;
using tabuleiro;

namespace Xadrez
{
	class PartidaDeXadrez
	{
		public Tabuleiro Tabuleiro { get; private set; }
		public int Turno { get; private set; }
		public Cor JogadorAtual { get; private set; }
		public bool Terminada { get; private set; }

		private HashSet<Peca> _pecasCapturadas;

		private HashSet<Peca> _pecas;

		public bool Xeque { get; private set; }

		public PartidaDeXadrez()
		{
			Tabuleiro = new Tabuleiro(8, 8);
			Turno = 1;
			JogadorAtual = Cor.Branca;
			Terminada = false;
			Xeque = false;
			_pecas = new HashSet<Peca>();
			_pecasCapturadas = new HashSet<Peca>();
			IniciarPecas();
		}

		public Peca ExecutaMovimento(Posicao posicaoOrigem, Posicao posicaoDestino)
		{
			Peca peca = Tabuleiro.RetirarPeca(posicaoOrigem);
			peca.IncrementaMovimento();
			Peca pecaCapturada = Tabuleiro.RetirarPeca(posicaoDestino);
			Tabuleiro.InserePeca(peca, posicaoDestino);
			if (pecaCapturada != null)
				_pecasCapturadas.Add(pecaCapturada);
			return pecaCapturada;
		}

		public void DesfazMovimento(Posicao posicaoOrigem, Posicao posicaoDestino, Peca pecaCapturada)
		{
			Peca pecaCapturadora = Tabuleiro.RetirarPeca(posicaoDestino);
			pecaCapturadora.DecrementaMovimento();
			if (pecaCapturada != null)
			{
				Tabuleiro.InserePeca(pecaCapturada, posicaoDestino);
				_pecasCapturadas.Remove(pecaCapturada);
			}
			Tabuleiro.InserePeca(pecaCapturadora, posicaoOrigem);

		}

		private Cor Adversario(Cor cor)
		{
			if (cor == Cor.Branca)
				return Cor.Preta;
			else
				return Cor.Branca;
		}

		private Peca Rei(Cor cor)
		{
			foreach (Peca rei in PecasEmJogo(cor))
			{
				if (rei is Rei)
				{
					return rei;
				}
			}
			return null;
		}

		public bool EstaEmXeque(Cor cor)
		{
			Peca rei = Rei(cor);
			if (rei == null)
				throw new TabuleiroExceptions("Não tem rei na cor " + cor + "no tabuleiro!");

			foreach (Peca peca in PecasEmJogo(Adversario(cor)))
			{
				bool[,] movimentos = peca.MovimentosPossiveis();
				if (movimentos[rei.Posicao.Linha, rei.Posicao.Coluna] == true)
				{
					return true;
				}
			}
			return false;
		}

		public bool TesteXequeMate(Cor cor)
		{
			if (!EstaEmXeque(cor))
			{
				return false;
			}
			foreach (Peca peca in PecasEmJogo(cor))
			{
				bool[,] movimentos = peca.MovimentosPossiveis();
				for (int i = 0; i < Tabuleiro.Linhas; i++)
				{
					for (int j = 0; j < Tabuleiro.Colunas; j++)
					{
						if (movimentos[i, j])
						{
							Posicao destino = new Posicao(i, j);
							Posicao origem = peca.Posicao;
							Peca pecaTeste = ExecutaMovimento(origem, destino);
							bool TesteXeque = EstaEmXeque(cor);
							DesfazMovimento(origem, destino, pecaTeste);
							if (!TesteXeque)
							{
								return false;
							}

						}
					}
				}

			}
			return true;
		}


		public HashSet<Peca> PecasCapturadas(Cor cor)
		{
			HashSet<Peca> aux = new HashSet<Peca>();
			foreach (Peca peca in _pecasCapturadas)
			{
				if (peca.Cor == cor)
					aux.Add(peca);
			}
			return aux;
		}

		public HashSet<Peca> PecasEmJogo(Cor cor)
		{
			HashSet<Peca> aux = new HashSet<Peca>();
			foreach (Peca peca in _pecas)
			{
				if (peca.Cor == cor)
					aux.Add(peca);
			}
			aux.ExceptWith(PecasCapturadas(cor));
			return aux;
		}


		public void MudaJogador()
		{
			if (JogadorAtual == Cor.Branca)
				JogadorAtual = Cor.Preta;
			else
				JogadorAtual = Cor.Branca;
		}

		public void RealizaJogada(Posicao posicaoOrigem, Posicao posicaoDestino)
		{
			Peca pecaCapturada = ExecutaMovimento(posicaoOrigem, posicaoDestino);

			if (EstaEmXeque(JogadorAtual))
			{
				DesfazMovimento(posicaoOrigem, posicaoDestino, pecaCapturada);
				throw new TabuleiroExceptions("Você está colocando seu rei em xeque!");
			}
			if (EstaEmXeque(Adversario(JogadorAtual)))
			{
				Xeque = true;
			}
			else
			{
				Xeque = false;
			}
			if (TesteXequeMate(Adversario(JogadorAtual)))
			{
				Terminada = true;
			}
			else
			{
				MudaJogador();
				Turno++;
			}
		}




		public void ColocarNovaPeca(char coluna, int linha, Peca peca)
		{
			Tabuleiro.InserePeca(peca, new PosicaoXadrez(coluna, linha).ConvertePosicao());
			_pecas.Add(peca);
		}

		private void IniciarPecas()
		{
			ColocarNovaPeca('c', 2, new Peao(Tabuleiro, Cor.Branca));
			ColocarNovaPeca('d', 2, new Peao(Tabuleiro, Cor.Branca));
			ColocarNovaPeca('e', 2, new Peao(Tabuleiro, Cor.Branca));
			ColocarNovaPeca('a', 2, new Peao(Tabuleiro, Cor.Branca));
			ColocarNovaPeca('f', 2, new Peao(Tabuleiro, Cor.Branca));
			ColocarNovaPeca('g', 2, new Peao(Tabuleiro, Cor.Branca));
			ColocarNovaPeca('h', 2, new Peao(Tabuleiro, Cor.Branca));
			ColocarNovaPeca('b', 2, new Peao(Tabuleiro, Cor.Branca));
			ColocarNovaPeca('c', 1, new Bispo(Tabuleiro, Cor.Branca));
			ColocarNovaPeca('f', 1, new Bispo(Tabuleiro, Cor.Branca));
			ColocarNovaPeca('b', 1, new Cavalo(Tabuleiro, Cor.Branca));
			ColocarNovaPeca('g', 1, new Cavalo(Tabuleiro, Cor.Branca));
			ColocarNovaPeca('a', 1, new Torre(Tabuleiro, Cor.Branca));
			ColocarNovaPeca('h', 1, new Torre(Tabuleiro, Cor.Branca));
			ColocarNovaPeca('e', 1, new Dama(Tabuleiro, Cor.Branca));
			ColocarNovaPeca('d', 1, new Rei(Tabuleiro, Cor.Branca));

			ColocarNovaPeca('a', 7, new Peao(Tabuleiro, Cor.Preta));
			ColocarNovaPeca('b', 7, new Peao(Tabuleiro, Cor.Preta));
			ColocarNovaPeca('c', 7, new Peao(Tabuleiro, Cor.Preta));
			ColocarNovaPeca('d', 7, new Peao(Tabuleiro, Cor.Preta));
			ColocarNovaPeca('e', 7, new Peao(Tabuleiro, Cor.Preta));
			ColocarNovaPeca('f', 7, new Peao(Tabuleiro, Cor.Preta));
			ColocarNovaPeca('g', 7, new Peao(Tabuleiro, Cor.Preta));
			ColocarNovaPeca('h', 7, new Peao(Tabuleiro, Cor.Preta));
			ColocarNovaPeca('c', 8, new Bispo(Tabuleiro, Cor.Preta));
			ColocarNovaPeca('f', 8, new Bispo(Tabuleiro, Cor.Preta));
			ColocarNovaPeca('b', 8, new Cavalo(Tabuleiro, Cor.Preta));
			ColocarNovaPeca('g', 8, new Cavalo(Tabuleiro, Cor.Preta));
			ColocarNovaPeca('a', 8, new Torre(Tabuleiro, Cor.Preta));
			ColocarNovaPeca('h', 8, new Torre(Tabuleiro, Cor.Preta));
			ColocarNovaPeca('e', 8, new Dama(Tabuleiro, Cor.Preta));
			ColocarNovaPeca('d', 8, new Rei(Tabuleiro, Cor.Preta)); ;
		}

		public void VerificaOrigem(Posicao origem)
		{
			Tabuleiro.ValidaPosicao(origem);

			if (Tabuleiro.GetPeca(origem) == null)
			{
				throw new TabuleiroExceptions("Digite uma posição válida para a origem!");
			}
			if (JogadorAtual != Tabuleiro.GetPeca(origem).Cor)
			{
				throw new TabuleiroExceptions("A peça de origem escolhida não é sua!");
			}
		}
		public void VerificaDestino(Posicao destino, bool[,] posicoesPossiveis)
		{
			Tabuleiro.ValidaPosicao(destino);
			if (posicoesPossiveis[destino.Linha, destino.Coluna] == false)
			{
				throw new TabuleiroExceptions("Digite uma posição válida para o destino!");
			}
		}
	}
}
