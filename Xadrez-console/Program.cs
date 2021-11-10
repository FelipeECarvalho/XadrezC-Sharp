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
					Tela.ImprimeTabuleiro(partida.Tabuleiro);
				
					Console.Write("Posição da peça: ");
					Posicao origem = PosicaoXadrez.LerPosicaoXadrez().ConvertePosicao();

					bool[,] posicoesPossiveis = partida.Tabuleiro.GetPeca(origem).MovimentosPossiveis();
					Console.Clear();
					Tela.ImprimeTabuleiro(partida.Tabuleiro, posicoesPossiveis);

					Console.Write("Posição de Destino: ");
					Posicao destino = PosicaoXadrez.LerPosicaoXadrez().ConvertePosicao();

					partida.ExecutaMovimento(origem, destino);
					Console.Clear();

				}
				catch (TabuleiroExceptions e)
				{
					Console.WriteLine();
					Console.WriteLine("ERROR: " + e.Message); ;
				}
			}

		}
	}
}
