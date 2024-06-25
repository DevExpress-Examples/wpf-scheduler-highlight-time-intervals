<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128655744/17.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T590114)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [MainWindow.xaml](./CS/SchedulerCellTemplate/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/SchedulerCellTemplate/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/SchedulerCellTemplate/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/SchedulerCellTemplate/MainWindow.xaml.vb))
* [TeamData.cs](./CS/SchedulerCellTemplate/TeamData.cs) (VB: [TeamData.vb](./VB/SchedulerCellTemplate/TeamData.vb))
<!-- default file list end -->
# How to color time cells partially


This example demonstrates how to indicate special time slots with a custom color with a minute accuracy.<br><br><img src="https://raw.githubusercontent.com/DevExpress-Examples/how-to-color-time-cells-partially-t590114/17.2.3+/media/f1fbb0a1-dcae-4756-8b80-da96524b9ca6.png">


### Description

To color time cells in a custom manner, a custom cell style with a CellControl's custom content template is used.&nbsp;To apply the custom cell style to a certain scheduler view, assign it to&nbsp;the &nbsp;ViewBase.CellStyle property. In this example, the cell style is customized for the DayView.

```xaml
<Style TargetType="dxsch:DayView">
     <Style.Triggers>
        <DataTrigger Binding="{Binding HighlightLunchHours}" Value="True">
            <Setter Property="CellStyle" Value="{StaticResource CellControl.Style}">
        </DataTrigger>
     </Style.Triggers>
</Style>
```
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-scheduler-highlight-time-intervals&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-scheduler-highlight-time-intervals&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
