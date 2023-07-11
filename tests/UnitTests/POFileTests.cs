using POtoResx;

namespace UnitTests;

public class POFileTests
{
    [Fact]
    public async Task ToDictionaryAsync_ValidFile_ReturnsCorrectDictionary()
    {
        Assert.Equal(
            new Dictionary<string, string>
            {
                ["AGlobalErrorOccurDuringTheUploadOfTheOrders:"] = "Un erreur générale est survenue durant la remontée des commandes::\n{0}",
                ["AllProgressWillBeLost"] = "Toute la progression sera perdue.",
                ["Amount"] = "Montant",
                ["Amount:"] = "Montant:",
                ["AreYouSureThatYouWantToDeletePaymentOfEuros"] = "Etes vous sure de vouloir supprimer le paiement {0} de {1} euros?",
                ["YouAreDeletingItemAreYouSureThatYouWantToContinue"] = "Vous effacer l'élément {0} \nEtes-vous sure de vouloir continuer?"
            },
            await new POFile("test_data.po").ToDictionaryAsync()
        );
    }

    [Fact]
    public Task ToDictionaryAsync_FileNotFound_ThrowsFileNotFoundException()
    {
        return Assert.ThrowsAsync<FileNotFoundException>(async () =>
            await new POFile("nonexistent_file.txt").ToDictionaryAsync()
        );
    }

    [Fact]
    public void Constuctor_NullFileName_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new POFile(null)
        );
    }
}
