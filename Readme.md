<!-- default file list -->
*Files to look at*:

* [MainWindow.xaml](./CS/SchedulerCellTemplate/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/SchedulerCellTemplate/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/SchedulerCellTemplate/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/SchedulerCellTemplate/MainWindow.xaml.vb))
* [TeamData.cs](./CS/SchedulerCellTemplate/TeamData.cs) (VB: [TeamData.vb](./VB/SchedulerCellTemplate/TeamData.vb))
<!-- default file list end -->
# How to highlight intervals in Scheduler


This example demonstrates how to indicate special time slots with a custom color with a minute accuracy.<br><br><img src="https://raw.githubusercontent.com/DevExpress-Examples/how-to-color-time-cells-partially-t590114/17.2.3+/media/f1fbb0a1-dcae-4756-8b80-da96524b9ca6.png">


<h3>Description</h3>

Starting with **v19.2**, SchedulerControl supports Time Regions. They allow you to highlight a certain group of cells (or their parts). For this purpose, it's sufficient to define a collection of such Time Region descriptors and use this collection in DataSource's **TimeRegionsSource** property. To declare mappings to properties from these descriptors, use the **TimeRegionMappings** object: 

```xaml
   <dxsch:DataSource ...
                     TimeRegionsSource="{Binding TimeRegions}">
		<dxsch:DataSource.TimeRegionMappings>
			<dxsch:TimeRegionMappings
					Id="Id" 
					ResourceId="CalendarId"
					Start="Start"
					End="End"
					Brush="Brush"
					RecurrenceInfo="RecurrenceInfo"
					/>
		</dxsch:DataSource.TimeRegionMappings>
		...
	</dxsch:DataSource>
```

In this example, the lunch time is highlighted with the help of such Time Regions. A collection of their descriptors are available from the **TimeRegions** property from the **CellCustomizationDemoViewModel** class. To repeat these regions, their **RecurrenceInfo** property contains corresponding recurrence settings. These settings are built with the help of the **RecurrenceBuilder** class.


<br/>


