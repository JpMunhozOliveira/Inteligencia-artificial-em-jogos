public class Populacao
{

    private Individuo[] individuos;
    private int tamPopulacao;

    public Populacao(int numGenes, int tamPop)
    {
        this.tamPopulacao = tamPop;
        this.individuos = new Individuo[tamPop];
        for (int i = 0; i < individuos.Length - 1; i++)
        {
            individuos[i] = new Individuo(numGenes);
        }
    }

    public Populacao(int TamPop)
    {
        this.tamPopulacao = TamPop;
        this.individuos = new Individuo[TamPop];
        for (int i = 0; i < this.individuos.Length; i++)
        {
            individuos[i] = null;
        }
    }

    public void setIndividuo(Individuo individuo, int posicao)
    {
        individuos[posicao] = individuo;
    }

    public void setIndividuo(Individuo individuo)
    {
        for (int i = 0; i < individuos.Length - 1; i++)
        {
            if (individuos[i] == null)
            {
                individuos[i] = individuo;
            }
        }
    }

    public bool temSolucao(string solucao)
    {
        Individuo? i = null;
        for (int j = 0; j < individuos.Length - 1; j++)
        {
            if (individuos[j].getGenes().Equals(solucao))
            {
                i = individuos[j];
                break;
            }
        }

        if (i == null)
        {
            return false;
        }
        return true;
    }

    public void ordenaPopulacao()
    {
        bool trocou = true;
        while (trocou)
        {
            trocou = false;
            for (int i = 0; i < individuos.Length - 1; i++)
            {
                if (individuos[i].getAptidao() < individuos[i + 1].getAptidao())
                {
                    Individuo temp = individuos[i];
                    individuos[i] = individuos[i + 1];
                    individuos[i + 1] = temp;
                    trocou = true;
                }
            }
        }
    }

    public int getNumIndividuos()
    {
        int num = 0;
        for (int i = 0; i < individuos.Length - 1; i++)
        {
            if (individuos[i] != null)
            {
                num++;
            }
        }
        return num;
    }

    public int getTamPopulacao()
    {
        return tamPopulacao;
    }

    public Individuo getIndividuo(int pos)
    {
        return individuos[pos];
    }
}