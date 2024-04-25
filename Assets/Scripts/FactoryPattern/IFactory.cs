using UnityEngine;

public interface IFactory
{
    ProductItem CreateProduct(ProductType type, Transform transform);
    Building CreateBuild(BuildingType type, Transform transform);
    Resource CreateResource(ResourceType type, Transform transform);
}