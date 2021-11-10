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

		public PartidaDeXadrez()
		{
			Tabuleiro = new Tabuleiro(8, 8);
			Turno = 1;
			JogadorAtual = Cor.Branca;
			Terminada = false;
			_pecas = new HashSet<Peca>();
			_pecasCapturadas = new HashSet<Peca>();
			IniciarPecas();
		}

		public void ExecutaMovimento(Posicao posicaoOrigem, Posicao posicaoDestino) 
		{
			Peca peca = Tabuleiro.RetirarPeca(posicaoOrigem);
			peca.IncrementaMovimento();
			Peca pecaCapturada = Tabuleiro.RetirarPeca(posicaoDestino);
			Tabuleiro.InserePeca(peca, posicaoDestino);
			if (pecaCapturada != null)
				_pecasCapturadas.Add(pecaCapturada);
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
			if (Tabuleiro.GetPeca(posicaoOrigem).Cor == Cor.Branca && JogadorAtual == Cor.Branca)
			{
				ExecutaMovimento(posicaoOrigem, posicaoDestino);
				MudaJogador();
				Turno++;
			}
			if (Tabuleiro.GetPeca(posicaoOrigem).Cor == Cor.Preta && JogadorAtual == Cor.Preta)
			{
				ExecutaMovimento(posicaoOrigem, posicaoDestino);
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
			ColocarNovaPeca('c', 1, new Torre(Tabuleiro, Cor.Branca));
			ColocarNovaPeca('c', 2, new Torre(Tabuleiro, Cor.Branca));
			ColocarNovaPeca('d', 2, new Torre(Tabuleiro, Cor.Branca));
			ColocarNovaPeca('e', 2, new Torre(Tabuleiro, Cor.Branca));
			ColocarNovaPeca('e', 1, new Torre(Tabuleiro, Cor.Branca));
			ColocarNovaPeca('d', 1, new Rei(Tabuleiro, Cor.Branca));

			ColocarNovaPeca('c', 7, new Torre(Tabuleiro, Cor.Preta));
			ColocarNovaPeca('c', 8, new Torre(Tabuleiro, Cor.Preta));
			ColocarNovaPeca('d', 7, new Torre(Tabuleiro, Cor.Preta));
			ColocarNovaPeca('e', 7, new Torre(Tabuleiro, Cor.Preta));
			ColocarNovaPeca('e', 8, new Torre(Tabuleiro, Cor.Preta));
			ColocarNovaPeca('d', 8, new Rei(Tabuleiro, Cor.Preta));;
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
