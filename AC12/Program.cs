using System;
using System.IO.Compression;

internal class Programa
{
    static void Main()
    {
        Nave naveBase = new Nave("NaveExploradora", 42, 1221);
        NaveCombate naveCombate = new NaveCombate("NaveCombate", 21, 452, 1000);
        NaveCombateyCarga naveEspecial = new NaveCombateyCarga(
            "NaveEspecial",
            2500,
            12312,
            1231,
            "RayoDestructor"
        );
        Console.WriteLine("Nave Basica:");
        Console.WriteLine("Escribe el peso actual:");
        int pesoBase = int.Parse(Console.ReadLine());
        naveBase.Activar(pesoBase);

        Console.WriteLine("¿Cuanta velocidad quieres aumentar?");
        int velocidadBase = int.Parse(Console.ReadLine());
        naveBase.AumentarVelocidad(velocidadBase);

        naveBase.Mision();

        Console.WriteLine("Nave Combate:");
        Console.WriteLine("Escribe el peso actual:");
        int pesoCombate = int.Parse(Console.ReadLine());
        naveCombate.Activar(pesoCombate);

        Console.WriteLine("¿Cuanta velocidad quieres aumentar?");
        int velocidadCombate = int.Parse(Console.ReadLine());
        naveCombate.AumentarVelocidad(velocidadCombate);

        naveCombate.Mision();
        naveCombate.Atacar();

        Console.WriteLine("Nave Especial:");
        Console.WriteLine("Escribe el peso actual:");
        int pesoEspecial = int.Parse(Console.ReadLine());
        naveEspecial.Activar(pesoEspecial);

        Console.WriteLine("¿Cuanta velocidad quieres aumentar?");
        int velocidadEspecial = int.Parse(Console.ReadLine());
        naveEspecial.AumentarVelocidad(velocidadEspecial);

        naveEspecial.Mision();
        naveEspecial.Atacar();
        naveEspecial.EjecutarPoder();
    }
}

class Nave
{
    public string Nombre { get; set; }
    public int Velocidad { get; set; }

    public int PesoMaximo { get; set; }

    public Nave(string nombre, int velocidad, int pesomaximo)
    {
        Nombre = nombre;
        Velocidad = velocidad;
        PesoMaximo = pesomaximo;
    }

    public virtual void Activar(int peso)
    {
        if (peso > PesoMaximo)
        {
            Console.WriteLine("La nave tiene demasiado peso");
        }
        else
        {
            Console.WriteLine("Nave Activada");
        }
    }

    public virtual void Mision()
    {
        Console.WriteLine("Nave basica enviada a una misión de exploración");
    }

    public virtual void AumentarVelocidad(int aumento)
    {
        int final = Velocidad + aumento;
        Console.WriteLine($"La velocidad actualizada es {final}");
    }
}

class NaveCombate : Nave
{
    public double PoderAtaque { get; set; }

    public NaveCombate(string nombre, int velocidad, int pesomaximo, double ataque)
        : base(nombre, velocidad, pesomaximo)
    {
        PoderAtaque = ataque;
    }

    public override void Mision()
    {
        Console.WriteLine("Nave de combate enviada a una misión de ataque");
    }

    public virtual void Atacar()
    {
        Random random = new Random();
        int numeroAleatorio = random.Next();
        if (PoderAtaque < numeroAleatorio)
        {
            Console.WriteLine("La nave ha perdido la batalla");
        }
        else
        {
            Console.WriteLine("La nave ha ganado");
        }
    }
}

class NaveCombateyCarga : NaveCombate
{
    public string Poder { get; set; }

    public NaveCombateyCarga(
        string nombre,
        int velocidad,
        int pesomaximo,
        double ataque,
        string poder
    )
        : base(nombre, velocidad, pesomaximo, ataque)
    {
        Poder = poder;
    }

    public override void Activar(int peso)
    {
        Console.WriteLine($"Nave activada, no tiene limite de peso, peso actual: {peso}");
        Console.WriteLine($"Nave especial, extra de ataque <599>");
    }

    public override void Atacar()
    {
        Random random = new Random();
        int numeroAleatorio = random.Next();
        if ((599 + PoderAtaque) > numeroAleatorio)
        {
            Console.WriteLine("La nave ha perdido la batalla");
        }
        else
        {
            Console.WriteLine("La nave ha ganado gracias a su poder de ataque extra");
        }
    }

    public override void Mision()
    {
        Console.WriteLine("La nave especial va a una mision contra varias tropas.");
    }

    public void EjecutarPoder()
    {
        Console.WriteLine($"La nave ha usado su poder especial {Poder}, es muy efectivo");
    }
}
