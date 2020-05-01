//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Full_GRASP_And_SOLID
{
    public class Recipe
    {
        private IList<IStep> steps = new List<IStep>();

        public Product FinalProduct { get; set; }

        //Se modifica el método AddStep para cumplir con el patrón creator, este método instancia steps.
        public IStep AddStep(Product product, int cuantity, Equipment equipment, int time)
        {
            IStep step = new Step(product, cuantity, equipment, time);
            steps.Add(step);
            return step;
        }

        public void RemoveStep(IStep step)
        {
            this.steps.Remove(step);
        }

        // Agregado por SRP
        public string GetTextToPrint()
        {
            Console.WriteLine("-----------------");
            Console.WriteLine(this.FinalProduct.Description);
            Console.WriteLine("-----------------");
            string result = $"Receta de {this.FinalProduct.Description}:\n";
            foreach (IStep step in this.steps)
            {
                result = result + step.GetTextToPrint() + "\n";
            }

            // Agregado por Expert
            result = result + $"Costo de producción: {this.GetProductionCost()}";

            return result;
        }

        // Agregado por Expert
        public double GetProductionCost()
        {
            double result = 0;

            foreach (IStep step in this.steps)
            {
                result = result + step.GetStepCost();
            }

            return result;
        }
    }
}