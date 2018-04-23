# How to color time cells partially


This example demonstrates how to indicate special time slots with a custom color with a minute accuracy.<br><br><img src="https://raw.githubusercontent.com/DevExpress-Examples/how-to-color-time-cells-partially-t590114/17.2.3+/media/f1fbb0a1-dcae-4756-8b80-da96524b9ca6.png">


<h3>Description</h3>

To color time cells in a custom manner, a custom cell style with a CellControl's custom content template is used.&nbsp;To apply the custom cell style to a certain scheduler view, assign it to&nbsp;the &nbsp;ViewBase.CellStyle property. In this example, the cell style is customized for the DayView.<br>
<code lang="xaml">  &lt;Style TargetType="dxsch:DayView"&gt;
            &lt;Style.Triggers&gt;
                &lt;DataTrigger Binding="{Binding HighlightLunchHours}" Value="True"&gt;
                    &lt;Setter Property="CellStyle" Value="{StaticResource CellControl.Style}"/&gt;
                &lt;/DataTrigger&gt;
            &lt;/Style.Triggers&gt;
  &lt;/Style&gt;</code>

<br/>


