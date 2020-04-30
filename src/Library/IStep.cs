//Se agrega una abstracción por si quisieramos agregar una clase de descuentos para cada paso por ejemplo.
namespace Full_GRASP_And_SOLID
{
     public interface IStep 
    {
        double GetStepCost();
        string GetTextToPrint();
    
    }
}