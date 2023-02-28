using System;

public class Algoritmo
{
    private static string? solucao;
    private static double taxaDeCossover;
    private static double taxaDeMutacao;
    private static string? caracteres;

    public static Populacao novaGeracao(Populacao populacao, bool elitismo)
    {
        Random r = new Random();

        Populacao novaPopulacao = new Populacao(populacao.getTamPopulacao());

        if (elitismo)
        {
            novaPopulacao.setIndividuo(populacao.getIndividuo(0));
        }

        while (novaPopulacao.getNumIndividuos() < novaPopulacao.getTamPopulacao())
        {
            //seleciona os 2 pais
            Individuo[] pais = selecaoTorneio(populacao);

            Individuo[] filhos = new Individuo[2];

            if (r.NextDouble() <= taxaDeCossover)
            {
                filhos = crossover(pais[1], pais[0]);
            }
            else
            {
                filhos[0] = new Individuo(pais[0].getGenes());
                filhos[1] = new Individuo(pais[1].getGenes());
            }

            novaPopulacao.setIndividuo(filhos[0]);
            novaPopulacao.setIndividuo(filhos[1]);
        }

        novaPopulacao.ordenaPopulacao();
        return novaPopulacao;
    }

    public static Individuo[] selecaoTorneio(Populacao populacao)
    {

        Random r = new Random();
        Populacao popIntermediaria = new Populacao(3);

        //seleciona aleatoriamente 3 individuos na população
        popIntermediaria.setIndividuo(populacao.getIndividuo(r.Next(populacao.getTamPopulacao())));
        popIntermediaria.setIndividuo(populacao.getIndividuo(r.Next(populacao.getTamPopulacao())));
        popIntermediaria.setIndividuo(populacao.getIndividuo(r.Next(populacao.getTamPopulacao())));

        //ordena a população
        popIntermediaria.ordenaPopulacao();

        //seleciona os dois melhores 
        Individuo[] pais = new Individuo[2];
        pais[0] = popIntermediaria.getIndividuo(0);
        pais[1] = popIntermediaria.getIndividuo(1);

        return pais;
    }

    public static Individuo[] crossover(Individuo individuo1, Individuo individuo2)
    {
        Random r = new Random();

        //sorteio do ponto de corte
        int pontoCorte1 = r.Next((individuo1.getGenes().Length / 2) - 2) + 1;
        int pontoCorte2 = r.Next((individuo1.getGenes().Length / 2) - 2) + individuo1.getGenes().Length / 2;

        Individuo[] filhos = new Individuo[2];

        string genePai1 = individuo1.getGenes();
        string genePai2 = individuo2.getGenes();

        string geneFilho1;
        string geneFilho2;

        //realiza o corte
        geneFilho1 = genePai1.Substring(0, pontoCorte1);
        geneFilho1 += genePai2.Substring(pontoCorte1, (pontoCorte2 - pontoCorte1));
        geneFilho1 += genePai1.Substring(pontoCorte2, ((genePai1.Length) - pontoCorte2));

        geneFilho2 = genePai2.Substring(0, pontoCorte1);
        geneFilho2 += genePai1.Substring(pontoCorte1, (pontoCorte2 - pontoCorte1));
        geneFilho2 += genePai2.Substring(pontoCorte2, ((genePai2.Length) - pontoCorte2));

        filhos[0] = new Individuo(geneFilho1);
        filhos[1] = new Individuo(geneFilho2);

        return filhos;
    }

    public static string getSolucao()
    {
        return solucao;
    }

    public static void setSolucao(string solucao)
    {
        Algoritmo.solucao = solucao;
    }

    public static double getTaxaDeCrossover()
    {
        return taxaDeCossover;
    }

    public static void setTaxaDeCrossover(double taxaDeCossover)
    {
        Algoritmo.taxaDeCossover = taxaDeCossover;
    }

    public static double getTaxaDeMutacao()
    {
        return taxaDeMutacao;
    }

    public static void setTaxaDeMutacao(double taxaDeMutacao)
    {
        Algoritmo.taxaDeMutacao = taxaDeMutacao;
    }

    public static string getCaracteres()
    {
        return caracteres;
    }

    public static void setCaracteres(string caracteres)
    {
        Algoritmo.caracteres = caracteres;
    }
}