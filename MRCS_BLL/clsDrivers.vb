Public Class clsDrivers
    Private m_MembershipNo As Long
    Private m_Name As String
    Private m_Surname As String
    Private m_DOB As Date
    Private m_Gender As String
    Private m_DateJoined As Date
    Private m_FeesDue As Decimal

    Public Sub New()

    End Sub

    Public Sub New(membershipNo As Long, name As String, surname As String, DOB As Date,
                   gender As String, dateJoined As Date, feesDue As Decimal)
        Me.m_MembershipNo = membershipNo
        Me.m_Name = name
        Me.m_Surname = surname
        Me.m_DOB = DOB
        Me.m_Gender = gender
        Me.m_DateJoined = dateJoined
        Me.m_FeesDue = feesDue
    End Sub

    Public Property MembershipNo()
        Get
            Return m_MembershipNo
        End Get
        Set(value)
            m_MembershipNo = value
        End Set
    End Property

    Public Property Name()
        Get
            Return m_Name
        End Get
        Set(value)
            m_Name = value
        End Set
    End Property

    Public Property Surname()
        Get
            Return m_Surname
        End Get
        Set(value)
            m_Surname = value
        End Set
    End Property

    Public Property DOB()
        Get
            Return m_DOB
        End Get
        Set(value)
            m_DOB = value
        End Set
    End Property

    Public Property Gender()
        Get
            Return m_Gender
        End Get
        Set(value)
            m_Gender = value
        End Set
    End Property

    Public Property DateJoined()
        Get
            Return m_DateJoined
        End Get
        Set(value)
            m_DateJoined = value
        End Set
    End Property

    Public Property FeesDue()
        Get
            Return m_FeesDue
        End Get
        Set(value)
            m_FeesDue = value
        End Set
    End Property

End Class
