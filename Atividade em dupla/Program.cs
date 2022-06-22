using System;

public class No
{
    public string elemento;
    public No ant = null;
    public No prox = null;
}

public class ListaDuplamenteEncadeada
{
    protected No cabeça = new No();
    protected No cauda = new No();
    protected int qtdElementos;

    public ListaDuplamenteEncadeada()
    {
        cabeça.prox = cauda;
        cabeça.ant = null;
        cabeça.elemento = "Isto é a cabeça";
        cauda.ant = cabeça;
        cauda.prox = null;
        cauda.elemento = "Isto é a cauda";
        qtdElementos = 0;
    }
    public void imprimirTudo()
    {
        No Aux;
        Aux = cabeça;
        for (int i = 0; i < qtdElementos; i++)
        {
            Aux = Aux.prox;
            Console.Write(Aux.elemento);
            Console.Write(";");
        }
        Console.WriteLine("");
    }
    public void Inserir(No k)
    {

        k.ant = cauda.ant;
        cauda.ant = k;
        k.prox = cauda;
        (k.ant).prox = k;
        qtdElementos++;
    }
}

class Pilha : ListaDuplamenteEncadeada
{
    public void Retirar()
    {
        No Aux = new No();
        if (qtdElementos > 0)
        {
            Aux = cauda;
            Aux = Aux.ant.ant;
            cauda.ant = Aux;
            qtdElementos--;
        }
    }
}

class Fila : ListaDuplamenteEncadeada
{
    public void Retirar()
    {
        No Aux = new No();
        if (qtdElementos > 0)
        {
            Aux = cabeça;
            Aux = Aux.prox.prox;
            cabeça.prox = Aux;
            qtdElementos--;
        }
    }
}

class Program
{
    public static void Main(string[] args)
    {
        No primeiro = new No();
        No segundo = new No();
        No terceiro = new No();
        primeiro.elemento = "primeiro";
        segundo.elemento = "segundo";
        terceiro.elemento = "terceiro";
        Pilha duracell = new Pilha();
        duracell.Inserir(primeiro);
        duracell.Inserir(segundo);
        duracell.Inserir(terceiro);
        Console.WriteLine("Pilha:");
        Console.WriteLine("Inserido tres elementos na pilha, primeiro,segundo,terceiro respectivamente.");
        Console.Write("Elementos: ");
        duracell.imprimirTudo();
        Console.WriteLine("\nOrdem de remoção:");
        for (int i = 0; i < 3; i++)
        {
            Console.Write("Elemento(s): ");
            duracell.Retirar();
            duracell.imprimirTudo();
        }
        Console.WriteLine("\n----------------\n");
        Console.WriteLine("Fila:");
        Fila filia = new Fila();
        filia.Inserir(primeiro);
        filia.Inserir(segundo);
        filia.Inserir(terceiro);
        Console.WriteLine("Inserido tres elementos na fila, primeiro,segundo,terceiro respectivamente.");
        Console.Write("Elementos: ");
        filia.imprimirTudo();
        
        Console.WriteLine("\nOrdem de remoção:");
        for (int i = 0; i < 3; i++)
        {
            Console.Write("Elemento(s): ");
            filia.Retirar();
            filia.imprimirTudo();
        }
    }
}