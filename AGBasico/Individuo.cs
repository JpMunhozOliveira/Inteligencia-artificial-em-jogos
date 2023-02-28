using System;

public class Individuo
{
    private string genes = "";
    private int aptidao = 0;

    public Individuo(int numGenes)
    {
        genes = "";

        Random r = new Random();
        string caracteres = Algoritmo.getCaracteres();
        for (int i = 0; i < numGenes; i++)
        {
            genes += caracteres[r.Next(caracteres.Length)];
        }

        gerarAptidao();
    }

    public Individuo(string genes)
    {
        this.genes = genes;
        Random r = new Random();

        if (r.NextDouble() <= Algoritmo.getTaxaDeMutacao())
        {
            string caracteres = Algoritmo.getCaracteres();
            string geneNovo = "";
            int posAleatoria = r.Next(genes.Length);

            for (int i = 0; i < genes.Length; i++)
            {
                if (i == posAleatoria)
                {
                    geneNovo += caracteres[r.Next(caracteres.Length)];
                }
                else
                {
                    geneNovo += genes[i];
                }
            }
            this.genes = geneNovo;
        }
        gerarAptidao();
    }

    public void gerarAptidao()
    {
        string solucao = Algoritmo.getSolucao();
        for (int i = 0; i < solucao.Length; i++)
        {
            if (solucao[i] == genes[i])
            {
                aptidao++;
            }
        }
    }

    public int getAptidao()
    {
        return aptidao;
    }

    public string getGenes()
    {
        return genes;
    }
}