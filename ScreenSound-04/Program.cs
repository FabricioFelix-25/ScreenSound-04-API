using ScreenSound_04.Modelos;
using System.Text.Json;
using ScreenSound_04.Filtros;

using (HttpClient client = new HttpClient())
{

    try
    {
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        Console.WriteLine(resposta);
        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta);
        //LinqFilter.FiltrarTodosOsGenerosMusicais(musicas);
        //LinqOrder.ExibirListaDeArtistaOrdenados(musicas);
        //LinqFilter.FiltrarArtistasPorGeneroMusical(musicas, "rock");
        

        var musicasPreferidasFabricio = new MusicasPreferidas("Fabricio");
        musicasPreferidasFabricio.AdicionarMusicasFavoritas(musicas[55]);
        musicasPreferidasFabricio.AdicionarMusicasFavoritas(musicas[666]);

        musicasPreferidasFabricio.ExibirMusicasFavoritas();
        musicasPreferidasFabricio.GerarArquivoJson();




    }
    catch (Exception ex)
    {
        Console.WriteLine($"Temos um problema: {ex.Message}");
    }


}