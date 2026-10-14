// Lab 5
// Student name:Manpreet Lalh
// Student number:21247325

using System;
using System.Collections.Generic;

Console.WriteLine("CPEN223 Lab 5");

//Testing: Write test cases that exercise all four methods you are to implement.
//TODO
//
//
//end Testing code

//Do not change the program skeleton: keep the class name, method names,
//parameters, and return types exactly as given.
//Do not use LINQ, and do not use Console inside the GraphLibrary methods.

public static class GraphLibrary
{
    /// <summary>
    /// Determines whether an undirected graph is connected.
    /// The graph is connected if every vertex can be reached from <paramref name="start"/>
    /// by following zero or more edges.
    /// An empty graph is considered connected.
    /// </summary>
    /// <param name="graph">
    /// The graph, represented as an adjacency list:
    /// each key is a vertex and its associated list contains that vertex's neighbours.
    /// </param>
    /// <param name="start">
    /// The vertex from which the traversal begins.
    /// </param>
    /// <returns>
    /// true if every vertex in <paramref name="graph"/> is reachable from
    /// <paramref name="start"/>; otherwise false.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown if the graph is non-empty and <paramref name="start"/> is not a vertex
    /// in the graph.
    /// </exception>
    /// <remarks>
    /// Assumes that <paramref name="graph"/> is a valid representation of an
    /// undirected graph:
    /// every neighbour appearing in an adjacency list is also a key in the graph,
    /// and if v lists w as a neighbour, then w lists v as a neighbour.
    /// The method does not modify the graph.
    /// </remarks>
    static bool IsConnected(
        IReadOnlyDictionary<string, HashSet<string>> graph, string start)
    {
        if (graph.Count == 0)
            return true;
        if (!graph.ContainsKey(start))
            throw new ArgumentException("start not in graph");

        /*HashSet<string> visited = new();
        Stack<string> work = new();
        work.Push(start);

        while (work.Count > 0)
        {
            string v = work.Pop();
            if (!visited.Add(v)) continue;

            foreach (string n in graph[v])
                work.Push(n);
        }
*/
        return ReachableFrom(graph, start) == graph.Count;
    }


    public static HashSet<string> ReachableFrom(
        IReadOnlyDictionary<string, HashSet<string>> graph,
        string start)
    {
        if(!graph.ContainsKey(start)){
            throw new ArgumentException("No start in the graph");
        }

        // is connected code and I want it to return what is connected has seen/"visited"
      HashSet<string> visited = new();
    Stack<string> work = new();

work.Push(start);

while (work.Count > 0)
{
    string v = work.Pop();
    if (!visited.Add(v)) continue;

    foreach (string n in graph[v])
    {
        work.Push(n);
    }
  
}
return(visited);

    }



    public static int CountComponents(
        IReadOnlyDictionary<string, HashSet<string>> graph)
    {
    if(graph.Count == 0){
        return 0; 
    }
    HashSet<string> globallyVisited = new();
    int compCount = 0; 

    foreach(string vertex in graph.Keys){
        if (!globallyVisited.Contains(vertex)){

            HashSet<string> component = ReachableFrom(graph, vertex);

            foreach(string v in component){

            globallyVisited.Add(v);
            }

            compCount++;
        }
    }
    return compCount;
    }


    public static int ShortestDistance(
        IReadOnlyDictionary<string, HashSet<string>> graph, string start, string target)
    {
        if(!graph.ContainsKey(start) || !graph.ContainsKey(target)){
            throw new ArgumentException("Start and Target need to be in graph");
        }
        if (start == target){
            return 0;
        }
        Queue<string> work = new();
        Dictionary<string, int> distances = new();

        work.Enqueue(start);
        distances[start] = 0; 

        while(work.Count > 0){
string v = work.Dequeue();

if (v == target){
    return distances[v];

}
foreach(string n in graph[v]){
    if(!distance.ContainsKey(n)){
        distances[n] = distances[v] + 1; 
        work.Enqueue(n);
    }
}
        }
        return -1; 
    }




}
