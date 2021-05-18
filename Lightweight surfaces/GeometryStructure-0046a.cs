
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
namespace ns0046a
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
        private void RunScript(object x, object y, ref object A, ref object GeoCylinder)
        {
            //Generate a random radius of a circle
            Random rand = new Random();
            double radius = rand.Next(10, 20);

            //Create xy_plane using the Plane static method WorldXY
            Plane plane = Plane.WorldXY;

            //Set plane origin to (2,1,0);
            Point3d center = new Point3d(2, 1, 0);
            plane.Origin = center;

            //Create a circle from plane and radius
            Circle circle = new Circle(plane, radius);

            //Create an arc from an input circle and interval
            Interval angleInterval = new Interval(0, Math.PI);

            Arc arc = new Arc(circle, angleInterval);
            A = arc;

            //Extract end points
            Point3d startPoint = arc.StartPoint;
            Point3d endPoint = arc.EndPoint;

            //Create a vertical vector
            Vector3d vec = Vector3d.ZAxis;
            //Use the multiplication operation to scale by 10
            vec = vec * 10;

            //Create start and end lines
            Line line1 = new Line(startPoint, vec);
            Line line2 = new Line(endPoint, vec);

            //Create a cylinder at line1 with radius = 1/4 the length
            double height = line1.Length;
            double radius2 = height / 4;
            Circle c_circle = new Circle(line1.From, radius2);
            Cylinder cylinder = new Cylinder(c_circle, height);
            GeoCylinder = cylinder;


        }
        #endregion

        #region Additional

        #endregion
    }
}
