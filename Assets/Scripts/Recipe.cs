public class Recipe {
    private RecipeSO recipeSO;
    private bool isUnlocked;

    public Recipe(RecipeSO recipeSO) {
        this.recipeSO = recipeSO;
        isUnlocked = recipeSO.unlockedByDefault;
    }
}