using System;
using tabuleiro;
using Xadrez;

namespace Xadrez_console
{
	class Program
	{
		static void Main(string[] args)
		{
			PartidaDeXadrez partida = new PartidaDeXadrez();
			while (!partida.Terminada)
			{
				try
				{
					Console.Clear();
					Tela.ImprimeTabuleiro(partida.Tabuleiro);
					Console.WriteLine();
					Console.WriteLine();
					Console.WriteLine("Turno: " + partida.Turno);
					Console.WriteLine("Aguardando a jogada das " + (partida.JogadorAtual).ToString() + "s");

					Console.WriteLine();
					Console.Write("Posição da peça: ");
					Posicao origem = PosicaoXadrez.LerPosicaoXadrez().ConvertePosicao();
					partida.VerificaOrigem(origem);

					bool[,] posicoesPossiveis = partida.Tabuleiro.GetPeca(origem).MovimentosPossiveis();
					Console.Clear();
					Tela.ImprimeTabuleiro(partida.Tabuleiro, posicoesPossiveis);


					Console.WriteLine();
					Console.WriteLine();
					Console.Write("Posição de Destino: ");
					Posicao destino = PosicaoXadrez.LerPosicaoXadrez().ConvertePosicao();
					partida.VerificaDestino(destino, posicoesPossiveis);


					partida.RealizaJogada(origem, destino);

				}
				catch (TabuleiroExceptions e)
				{
					Console.WriteLine("ERROR: " + e.Message);
					Console.ReadKey();
				}
			}

		}
	}
}
