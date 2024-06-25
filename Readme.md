<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128655744/19.2.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T590114)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# WPF Scheduler - Highlight Time Intervals

This example uses [Time Regions](https://docs.devexpress.com/WPF/401378/controls-and-libraries/scheduler/time-regions) to highlight time intervals with custom colors.

![image](./media/f1fbb0a1-dcae-4756-8b80-da96524b9ca6.png) 

## Implementation Details

[Time Regions](https://docs.devexpress.com/WPF/401378/controls-and-libraries/scheduler/time-regions) allow you to highlight a group of cells (or their parts). To do this, define a collection of Time Region descriptors and assign this collection to the [DataSource.TimeRegionsSource](https://docs.devexpress.com/WPF/DevExpress.Xpf.Scheduling.DataSource.TimeRegionsSource) property. Use the [TimeRegionMappings](https://docs.devexpress.com/WPF/DevExpress.Xpf.Scheduling.TimeRegionMappings) object to declare mappings to properties from these descriptors:

```xaml
<dxsch:DataSource ...
                  TimeRegionsSource="{Binding TimeRegions}">
    <dxsch:DataSource.TimeRegionMappings>
        <dxsch:TimeRegionMappings Id="Id" 
                                  ResourceId="CalendarId"
                                  Start="Start"
                                  End="End"
                                  Brush="Brush"
                                  RecurrenceInfo="RecurrenceInfo"/>
    </dxsch:DataSource.TimeRegionMappings>
</dxsch:DataSource>
```

## Files to Review

* [MainWindow.xaml](./CS/SchedulerCellTemplate/MainWindow.xaml)
* [MainWindow.xaml.cs](./CS/SchedulerCellTemplate/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/SchedulerCellTemplate/MainWindow.xaml.vb))
* [TeamData.cs](./CS/SchedulerCellTemplate/TeamData.cs) (VB: [TeamData.vb](./VB/SchedulerCellTemplate/TeamData.vb))

## Documentation

* [Time Regions](https://docs.devexpress.com/WPF/401378/controls-and-libraries/scheduler/time-regions)
* [TimeRegionMappings](https://docs.devexpress.com/WPF/DevExpress.Xpf.Scheduling.TimeRegionMappings)

## More Examples

* [WPF Scheduler - Customize Cell Colors](https://github.com/DevExpress-Examples/wpf-scheduler-customize-cell-colors)
* [WPF Scheduler - Disable Resource Colorization](https://github.com/DevExpress-Examples/wpf-scheduler-disable-resource-colorization)
* [WPF Scheduler - Filter Time Regions](https://github.com/DevExpress-Examples/wpf-scheduler-filter-time-regions)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-scheduler-highlight-time-intervals&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-scheduler-highlight-time-intervals&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
