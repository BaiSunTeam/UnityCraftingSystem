using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour {
    private List<Recipe> recipeList;
    private Inventory inventory;

    private void Awake() {
        recipeList = new List<Recipe>();
        LoadAllRecipes();
    }

    private void LoadAllRecipes() {
        RecipeSO[] loadedRecipeSO = Resources.LoadAll<RecipeSO>("Recipes");

        foreach (RecipeSO recipeSO in loadedRecipeSO) {
            recipeList.Add(new Recipe(recipeSO));
        }

        Debug.Log($"Loaded {recipeList.Count} recipes");
    }
    
    public void SetInventory(Inventory inventory) {
        this.inventory = inventory;
    }
}