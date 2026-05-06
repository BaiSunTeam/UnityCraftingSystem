using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RecipeSO", menuName = "ScriptableObjects/RecipeSO")]
public class RecipeSO : ScriptableObject {
    // Item Data
    public ItemSO output;
    public int outputAmount;
    public List<Ingredient> requiredIngredients;
    public bool unlockedByDefault;
}
