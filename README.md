# Assignment2
A C# implementation of the MyList interface, called MyArrayList, has methods for adding/removing elements, getting the list's size, and sorting.
MyArrayList has a private T[] variable for the list's elements and an int size for element count. The class implements MyList's add, add with index, remove, get, clear, size, contains, indexof, lastindexof, and sort methods.
Add method checks if the array has enough space. If not, it creates a new array with double size, copies the elements, and adds the new element. Otherwise, it adds to end and increments size.
Remove method removes an element at an index, shifts subsequent elements left by one, and reduces size.
The size method returns MyArrayList's object size.
contains() method checks if MyArrayList contains a specific object. It iterates through the elements array with a for loop and compares each element using Equals(). If there's a match, it returns true. Otherwise, false.
indexof() and lastindexof() return the first and last occurrence index of a specified object in MyArrayList.
MyArrayList's sort method orders its elements in ascending order.
To use MyArrayList, just make a new instance and use its methods. It doesn't rely on .NET's built-in ArrayList or LinkedList classes.
