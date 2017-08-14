Public Class clsEvents
    Private m_Title As String
    Private m_DOE As Date
    Private m_RegFee As Decimal
    Private m_Location As String
    Private m_NumberOfLaps As Integer

    Public Sub New()

    End Sub

    Public Sub New(title As String, DOE As Date, regFee As Decimal, location As String, numberOfLaps As Integer)
        Me.m_Title = title
        Me.m_DOE = DOE
        Me.m_RegFee = regFee
        Me.m_Location = location
        Me.m_NumberOfLaps = numberOfLaps
    End Sub

    Public Property Title()
        Get
            Return m_Title
        End Get
        Set(value)
            m_Title = value
        End Set
    End Property

    Public Property DOE()
        Get
            Return m_DOE
        End Get
        Set(value)
            m_DOE = value
        End Set
    End Property

    Public Property RegFee()
        Get
            Return m_RegFee
        End Get
        Set(value)
            m_RegFee = value
        End Set
    End Property

    Public Property Location()
        Get
            Return m_Location
        End Get
        Set(value)
            m_Location = value
        End Set
    End Property

    Public Property NumberOfLaps()
        Get
            Return m_NumberOfLaps
        End Get
        Set(value)
            m_NumberOfLaps = value
        End Set
    End Property
End Class
