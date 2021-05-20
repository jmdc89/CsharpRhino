
using System;
using System.Collections;
using System.Collections.Generic;

using Rhino;
using Rhino.Geometry;

using Grasshopper;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;

// Non-default includes.

/// Unique namespace, so visual studio won't throw any errors about duplicate definitions.
namespace ns23841
{
    /// <summary>
    /// This class will be instantiated on demand by the Script component.
    /// </summary>
    public class Script_Instance : GH_ScriptInstance
    {
	    /// This method is added to prevent compiler errors when opening this file in visual studio (code) or rider.
	    public override void InvokeRunScript(IGH_Component owner, object rhinoDocument, int iteration, List<object> inputs, IGH_DataAccess DA)
        {
            throw new NotImplementedException();
        }

        #region Utility functions
        /// <summary>Print a String to the [Out] Parameter of the Script component.</summary>
        /// <param name="text">String to print.</param>
        private void Print(string text) { /* Implementation hidden. */ }
        /// <summary>Print a formatted String to the [Out] Parameter of the Script component.</summary>
        /// <param name="format">String format.</param>
        /// <param name="args">Formatting parameters.</param>
        private void Print(string format, params object[] args) { /* Implementation hidden. */ }
        /// <summary>Print useful information about an object instance to the [Out] Parameter of the Script component. </summary>
        /// <param name="obj">Object instance to parse.</param>
        private void Reflect(object obj) { /* Implementation hidden. */ }
        /// <summary>Print the signatures of all the overloads of a specific method to the [Out] Parameter of the Script component. </summary>
        /// <param name="obj">Object instance to parse.</param>
        private void Reflect(object obj, string method_name) { /* Implementation hidden. */ }
        #endregion
        #region Members
        /// <summary>Gets the current Rhino document.</summary>
        private readonly RhinoDoc RhinoDocument;
        /// <summary>Gets the Grasshopper document that owns this script.</summary>
        private readonly GH_Document GrasshopperDocument;
        /// <summary>Gets the Grasshopper script component that owns this script.</summary>
        private readonly IGH_Component Component;
        /// <summary>
        /// Gets the current iteration count. The first call to RunScript() is associated with Iteration==0.
        /// Any subsequent call within the same solution will increment the Iteration count.
        /// </summary>
        private readonly int Iteration;
        #endregion
        /// <summary>
        /// This procedure contains the user code. Input parameters are provided as regular arguments,
        /// Output parameters as ref arguments. You don't have to assign output parameters,
        /// they will have a default value.
        /// </summary>
        #region Runscript
        private void RunScript(Surface srf, int num, double dis, double tol, ref object A)
        {
            bool isClosedU = srf.IsClosed(0);
            bool isClosedV = srf.IsClosed(1);

            bool isPlanar = srf.IsPlanar();

            double u = 0.5;
            double v = 0.5;

            Point3d evalPt = new Point3d(Point3d.Unset);
            Vector3d[] derivatives = {};

            srf.Evaluate(u, v, 1, out evalPt, out derivatives);

            Vector3d tanU = derivatives[0];
            Vector3d tanV = derivatives[1];

            /*List<Surface> srfs = new List<Surface>();

            Surface lastSrf = srf;
            for (int i = 1; i <= num; i++) {
                Surface offsetSrf = lastSrf.Offset(dis, tol);
                if (srf.IsValid) {
                    //append offset surface to array
                    srfs.Add(offsetSrf);
                    //update the next curve to offset
                    lastSrf = offsetSrf;
                }
                else
                    break;
            }

            A = srfs;+
 */
            
            


        }
        #endregion

        #region Additional

        #endregion
    }
}
