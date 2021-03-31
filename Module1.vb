Module Module1
    Function CheckApplicationIsRun(ByVal szExeFileName As String) As Boolean '检测进程
        On Error GoTo Err
        Dim WMI
        Dim Obj
        Dim Objs
        CheckApplicationIsRun = False
        WMI = GetObject("WinMgmts:")
        Objs = WMI.InstancesOf("Win32_Process")
        For Each Obj In Objs
            If InStr(UCase(szExeFileName), UCase(Obj.Description)) <> 0 Then
                CheckApplicationIsRun = True
                If Not Objs Is Nothing Then Objs = Nothing
                If Not WMI Is Nothing Then WMI = Nothing
                Exit Function
            End If
        Next
        If Not Objs Is Nothing Then Objs = Nothing
        If Not WMI Is Nothing Then WMI = Nothing
        Exit Function
Err:
        If Not Objs Is Nothing Then Objs = Nothing
        If Not WMI Is Nothing Then WMI = Nothing
    End Function
End Module
