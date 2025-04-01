using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounter : BaseCounter
{
    [SerializeField]private KitchenObjectSO plateSO;
    [SerializeField]private float spawnRate = 3;
    [SerializeField] private int plateCountMax = 5;

    private List<KitchenObject> plateList = new List<KitchenObject>();

    private float timer = 0;

    private void Update()
    {
        if (plateList.Count < plateCountMax)
        {
            timer += Time.deltaTime;
        }
          
        if (timer > spawnRate)
        {
            timer = 0;
            SpawnPlate();
        }
    }
    public override void Interact(Player player)
    {
        if (player.IsHaveKitchenObject() == false) 
        {//手上没食材
            if (plateList.Count > 0) 
            {
                player.AddKitchenObject(plateList[plateList.Count - 1]);
                plateList.RemoveAt(plateList.Count - 1);
            }
          
        }
    }

    public void SpawnPlate()
    {
        if (plateList.Count >= plateCountMax)
        {
            timer = 0;
            return; 
        }
        KitchenObject kitchenObject = GameObject.Instantiate(plateSO.prefab, GetHoldPoint()).GetComponent<KitchenObject>();

        kitchenObject.transform.localPosition = Vector3.zero + Vector3.up * 0.1f * plateList.Count;

        plateList.Add(kitchenObject);
    }
}
