SELECT 
	 u.[Id]
    ,u.[BirthDate]
    ,u.[Email]
    ,u.[EmailConfirmed]
    ,u.[PasswordHash]
    ,u.[SecurityStamp]
    ,u.[PhoneNumber]
    ,u.[PhoneNumberConfirmed]
    ,u.[TwoFactorEnabled]
    ,u.[LockoutEndDateUtc]
    ,u.[LockoutEnabled]
    ,u.[AccessFailedCount]
    ,u.[UserName]
    ,u.[Location]
    ,u.[DisplayName]
    ,u.[Avatar]
    ,u.[About]
	,r.Name as "RoleName"
  FROM 
	[AspNetUsers] u left outer join 
	  [AspNetUserRoles] ur on ur.UserId = u.Id 
	  left outer join [AspNetRoles] r on ur.RoleId = r.Id
