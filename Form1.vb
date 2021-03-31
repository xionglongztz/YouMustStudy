Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load '启动前
        TopMost = True '窗口置顶防止忽略
        Timer1.Enabled = True '启动计时器
        SetPriorityClass(GetCurrentProcess(), 64) '设置低优先级，防止占用资源过多
        Opacity = 0 '设置窗口透明度为0
        If UBound(Diagnostics.Process.GetProcessesByName(Diagnostics.Process.GetCurrentProcess.ProcessName)) > 0 Then '如果多开
            Dispose() '就关闭多打开的
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick '主循环
        If (CheckApplicationIsRun("steam.exe")) Then  '如果打开了steam.exe
            Show() '显示窗口
            Timer1.Enabled = False '关闭第一循环
            FlashWindow(Handle, 1) '闪烁标题栏以引起注意
            Dim mw = "" & IO.Path.GetFileName(Application.ExecutablePath) & "检测到你正在试图打开steam，请立即关闭steam，否则系统将在2分钟后关机！"" "
            Shell("shutdown.exe" & " -s -t 120 -c " & mw, 2) '进行关机操作
            Timer2.Enabled = True '启动第二循环
        Else
            Hide()
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick '第二循环
        If (CheckApplicationIsRun("steam.exe")) Then  '如果依然存在steam.exe
            'MsgBox("哼，雕虫小技竟敢班门弄斧，你自己关没关steam心里没点B数？", MsgBoxStyle.Critical, "你在逗我玩呢吧")
            'MsgBox("赶紧去看看进程是不是真的关了，我的小宝贝，球球你惹")
            'Dim Ques2 = MsgBox("确定要强行关闭steam.exe进程吗（可能会丢失数据）" & vbCrLf & "（结束后需要重新点击本按钮以验证是否结束）", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "提醒")
            'If Ques2 = MsgBoxResult.Yes Then '点了是
            '    Shell("taskkill.exe" & " /f /t /im steam.exe", 2) '强行关闭进程
            'Else '否则
            '    MsgBox("我在这里等待你,快去关吧，关了记得点这里验证")
            'End If
            'MsgBox("你没有关闭steam，禁止解除关机，请检查是否真正关闭steam后重试")
        Else
            Shell("shutdown.exe" & " -a", 2) '解除
            Timer1.Enabled = True '启动第一循环
            Timer2.Enabled = False '取消第二循环
            Hide() '隐藏窗口
        End If
    End Sub
End Class
