Module Module2 'api
    Public Declare Function FlashWindow Lib "user32" (ByVal hwnd As Long, ByVal bInvert As Long) As Long '闪烁窗口（0维持最初，1切换标题）
    Public Declare Function SetPriorityClass Lib "kernel32" (ByVal hProcess As Long, ByVal dwPriorityClass As Long) As Long '设置进程优先级
    Public Declare Function GetCurrentProcess Lib "kernel32" () As Long '获取当前进程句柄
    Public Declare Function GetPriorityClass Lib "kernel32" (ByVal hProcess As Long) As Long '获取进程优先级
End Module
