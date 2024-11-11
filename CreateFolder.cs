using System;
using System.IO;
using System.Runtime.CompilerServices;
// importar arquivo que irá pegar nome, caminho, freq_uso

class CreateFolderInUserProfile {
    private string basePath;
    private string folderPath;

    public CreateFolderInUserProfile() {
        this.basePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile); // Caminho para pasta base
        this.folderPath = Path.Combine(basePath, "Dock"); // Cria a pasta

        // Verifica se a pasta já existe e cria se não existir
        if (!Directory.Exists(folderPath)) {
            Directory.CreateDirectory(folderPath);
        }
    }

    public string GetBasePath() {
        return basePath;
    }

    public string GetFolderPath() {
        return folderPath;
    }

   // Método para criar o arquivo CSV na pasta "Dock"
    public void CreateCSVInPathDock() {

        string csvFilePath = Path.Combine(folderPath, "Dock_Atalho.csv");
        // Verifica se existe csv
        if (!Directory.Exists(csvFilePath)) {

            Directory.CreateDirectory(csvFilePath);

            using (StreamWriter sw = new StreamWriter(csvFilePath)) {
            
                // Passar classe importada e utilizar metodo que pega caminho aplicativo
                string nome = "spotify"; // Colocar nome do app
                string caminho = "../algum_caminho"; // Colocar caminho da paste do mesmo
                string freq_uso = "00000110"; // Obter frequência de uso
                sw.WriteLine("nome,caminho,freq_uso"); // Cabeçalho do csv
                sw.WriteLine(nome, caminho, freq_uso);
            }
        }
        // Caso já tenha um arquivo csv
        using (StreamWriter sw = new StreamWriter(csvFilePath)) {
            string nome = "spotify";
            string caminho = "../algum_caminho";
            string freq_uso = "00000110";
            sw.WriteLine("nome,caminho,freq_uso");
            sw.WriteLine(nome, caminho, freq_uso); 
        }
    }

    // Método principal para executar o código
    static void Main() {
        // Cria uma instância de CreateFolderInUserProfile
        CreateFolderInUserProfile folderCreator = new CreateFolderInUserProfile();

        // Chama o método para criar o arquivo CSV
        folderCreator.CreateCSVInPathDock();
    }
}