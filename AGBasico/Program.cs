using System;

class Program
{
    static void Main(string[] args)
    {
        //Define a solução
        Algoritmo.setSolucao("Olá Mundo");
        //Define os caracteres existentes
        Algoritmo.setCaracteres("!,.:;?áÁãÃâÂõÕôÔóÓéÉêÊíÍQWERTYUIOPASDFGHJKLÇZXCVBNMqwertyuiopasdfghjklçzxcvbnm1234567890 ");
        //taxa de crossover de 60%
        Algoritmo.setTaxaDeCrossover(0.6);
        //taxa de mutação de 3%
        Algoritmo.setTaxaDeMutacao(0.3);
        //elitismo
        bool eltismo = true;
        //tamanho da população
        int tamPop = 100;
        //numero máximo de gerações
        int numMaxGeracoes = 10000;

        //define o número de genes do indivíduo baseado na solução
        int numGenes = Algoritmo.getSolucao().Length;

        //cria a primeira população aleatérioa
        Populacao populacao = new Populacao(numGenes, tamPop);

        bool temSolucao = false;
        int geracao = 0;

        Console.WriteLine("Iniciando... Aptidão da solução: "+Algoritmo.getSolucao().Length);
        
        //loop até o critério de parada
        while (!temSolucao && geracao < numMaxGeracoes) {
            geracao++;

            //cria nova populacao
            populacao = Algoritmo.novaGeracao(populacao, eltismo);

            Console.WriteLine("Geração " + geracao + " | Aptidão: " + populacao.getIndividuo(0).getAptidao() + " | Melhor: " + populacao.getIndividuo(0).getGenes());
            
            //verifica se tem a solucao
            temSolucao = populacao.temSolucao(Algoritmo.getSolucao());
        }

        if (geracao == numMaxGeracoes) {
           Console.WriteLine("Número Maximo de Gerações | " + populacao.getIndividuo(0).getGenes() + " " + populacao.getIndividuo(0).getAptidao());
        }

        if (temSolucao) {
            Console.WriteLine("Encontrado resultado na geração " + geracao + " | " + populacao.getIndividuo(0).getGenes() + " (Aptidão: " + populacao.getIndividuo(0).getAptidao() + ")");
        }
    }
}