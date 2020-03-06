1. PLUGIN SETUP
----------------------------------------------------------------------------------------------------
In order to start using the tool, create an empty game object, attach the 'Octave3D World Builder' 
script to it and you are good to go. For more info on how to use the tool, please check out the video 
tutorials (http://bit.ly/2aBS9TX). 

2. VERSION INFO
----------------------------------------------------------------------------------------------------
Please consult the 'Version History.txt' file to view the changes that were made for the current version.

3. PLEASE READ
----------------------------------------------------------------------------------------------------
-Starting with Octave3D Version 2.2, the tool no longer forces the spawned objects to be children of the 
 Octave3D object. If you would like to keep this arrangement you can right click on the Octave3D object 
 in the hierarchy view and select Octave3D->Set as ObjectGroup. Then make sure this group is active and 
 the 'Attach to object group' toggle is checked. This will allow you to keep attaching spawned objects to 
 the Octave3D object.

-There is new window available in Tools->Octave3D->Fix... which allows you to fix a bug that was causing 
 stray objects to be left behind after Resetting the Octave3D script component. These were objects used 
 internally by Octave3D to store different types of data. Pressing the Fix button in this window will 
 cleanup the scene of any such stray objects. This fix is also necessary when upgrading from an earlier
 version to 2.2 or above.

-Some of the Editor Windows that you might have open can disappear after script recompile. I do not believe 
 this is Octave's fault. Seems more like a bug to me. Seems to be a known issue for some time: http://bit.ly/2qXau8U

-Starting with the latest version, you will need to press the 'Refresh scene' (below the main toolbar) button 
 when you attach objects manually as children of the Octave3D object. Otherwise, you will not be able to 
 interact with these objects.

-If you get an error regarding a file named "GridTilePaintBrushEditWindow.cs" or any other file with the .cs 
 extension upon package update it means you have been using a version which was using files that have been 
 removed from the project in newer updates. You simply need to delete the existing Octave3D World Builder 
 package from your project and do a clean import.

Enjoy!