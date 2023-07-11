using CrudTransaccion.Models;
using CrudTransaccion.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;
using System.Reflection.Metadata;

class Program
{
    static void Main(string[] args)
    {
        addTemaSolistaTransaction();
    }

    public static void addTemaSolistaTransaction()
    {
        Console.WriteLine("Metodo agregar lIBRO,  autor,  genero");
        AplicationDbContext context = new AplicationDbContext();
        Libro libro = new Libro();
        Autor autor = new Autor();
        Genero genero = new Genero();
        var transaction = context.Database.BeginTransaction();

        try
        {
            //Agregar Autor
            autor.Name = "Anne Barry";
            autor.edad = 36;
            context.SaveChanges();

            //Agregar Genero
            genero.Categoria = "Accion";
            context.SaveChanges();

            //Agregar Libro
            libro.Titulo = "The black haw";
            libro.Paginas = 240;
            libro.genero = genero;
            libro.autor = autor;

            context.Libros.Add(libro);
            context.SaveChanges();

            if (string.IsNullOrEmpty(autor.Name) || genero.Categoria == null || libro.Titulo == null)
            {
                Console.WriteLine("Ha ingresado uno o más campos vacíos. Rollback ejecutado.");
                transaction.Rollback();
            }
            else
            {
                transaction.Commit();
                Console.WriteLine("Datos agregados exitosamente");
            }

        }
        catch (Exception e)
        {
            transaction.Rollback();
            Console.WriteLine("Error " + e.ToString());
        }
    }
}


}
