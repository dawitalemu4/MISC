Get-Process | Where-Object {$_.ProcessName -like 'W*'}

Get-Process | Where-Object {$_.ProcessName -like 'W*'} | ConvertTo-Html | Out-File "processes_starting_with_W.html"

Get-Process | Where-Object {$_.ProcessName -like 'W*'} | Export-Csv "processes_starting_with_W.csv" -NoTypeInformation

Start-Process iexplore

Stop-Process -Name iexplore
