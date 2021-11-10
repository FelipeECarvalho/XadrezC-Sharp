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
		private List<Peca> _pecasCapturadas = new List<Peca>();

		public PartidaDeXadrez()
		{
			Tabuleiro = new Tabuleiro(8, 8);
			Turno = 1;
			JogadorAtual = Cor.Branca;
			Terminada = false;
			IniciarPecas();
		}

		public void ExecutaMovimento(Posicao posicaoOrigem, Posicao posicaoDestino) 
		{
			if (Tabuleiro.GetPeca(posicaoOrigem) == null)
				throw new TabuleiroExceptions("Escolha uma peça válida");
			Peca peca = Tabuleiro.RetirarPeca(posicaoOrigem);
			_pecasCapturadas.Add(Tabuleiro.RetirarPeca(posicaoDestino));
			Tabuleiro.InserePeca(peca, posicaoDestino);
			Turno++;
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
			if (Tabuleiro.GetPeca(posicaoOrigem).Cor == Cor.Branca && JogadorAtual == Cor.Branca)
			{
				ExecutaMovimento(posicaoOrigem, posicaoDestino);
				MudaJogador();
			}
			else if (Tabuleiro.GetPeca(posicaoOrigem).Cor == Cor.Preta && JogadorAtual == Cor.Preta)
			{
				ExecutaMovimento(posicaoOrigem, posicaoDestino);
				MudaJogador();
			}
		}


		private void IniciarPecas()
		{
			Tabuleiro = new Tabuleiro(8, 8);
			Tabuleiro.InserePeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez('c', 1).ConvertePosicao());
			Tabuleiro.InserePeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez('c', 2).ConvertePosicao());
			Tabuleiro.InserePeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez('d', 2).ConvertePosicao());
			Tabuleiro.InserePeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez('e', 2).ConvertePosicao());
			Tabuleiro.InserePeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez('e', 1).ConvertePosicao());
			Tabuleiro.InserePeca(new Rei(Tabuleiro, Cor.Branca), new PosicaoXadrez('d', 1).ConvertePosicao());

			Tabuleiro.InserePeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrez('c', 7).ConvertePosicao());
			Tabuleiro.InserePeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrez('c', 8).ConvertePosicao());
			Tabuleiro.InserePeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrez('d', 7).ConvertePosicao());
			Tabuleiro.InserePeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrez('e', 7).ConvertePosicao());
			Tabuleiro.InserePeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrez('e', 8).ConvertePosicao());
			Tabuleiro.InserePeca(new Rei(Tabuleiro, Cor.Preta), new PosicaoXadrez('d', 8).ConvertePosicao());
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
