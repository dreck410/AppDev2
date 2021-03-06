/****** Object:  StoredProcedure [FacInDept]    Script Date: 12/8/2014 2:42:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [FacInDept]
 @dept VARCHAR(10)
AS
 SELECT * FROM Faculty WHERE FacDept LIKE @dept + '%';
GO
/****** Object:  StoredProcedure [LeastUsedSongs]    Script Date: 12/8/2014 2:42:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [LeastUsedSongs]ASSELECT Top 10SongUsageView.TitleFROM SongUsageViewORDER BY LastUsedDate ASC, Title 
GO
/****** Object:  StoredProcedure [UpdateGrade]    Script Date: 12/8/2014 2:42:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [UpdateGrade]
 @OfferNo Int
 ,@SSN CHAR(9)
 ,@GRADE INT
 
AS
	DECLARE @error_message nvarchar(255)
	SET @error_message = 'Completed'
	IF NOT EXISTS (Select StdSSN from Enrollment where StdSSN = @SSN AND OfferNo = @OfferNo) 
	BEGIN	
		SET @error_message ='Student not enrolled in specified offering'
		RAISERROR (@error_message, 11,1)
	END
	ELSE
		IF(@GRADE < 0 or @Grade > 100)
		BEGIN
			SET @error_message ='GRADE IS NOT IN THE RANGEE 0..100'
			RAISERROR (@error_message, 10,1)
		END
		ELSE
			--if(@error_message = 'Completed')
			UPDATE Enrollment
			Set Enrollment.EnrGrade = (@GRADE * 4 * .01)
			FROM Enrollment
			WHERE Enrollment.StdSSN = @SSN AND Enrollment.OfferNo = @OfferNo;
				
			RETURN (@GRADE * 4 * 0.01)
			--RAISERROR (@error_message, 10,1)
GO
/****** Object:  View [SongUsageView]    Script Date: 12/8/2014 2:42:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [SongUsageView] AS select 
                Max(Service.Svc_DateTime) as LastUsedDate
                ,Song.Song_ID, Song.Title, Song.Arranger, Song.Hymnbook_Num, Song.Song_Type
                from Song
                Left Join ServiceEvent on Song.Song_ID = ServiceEvent.Song_ID
                Left Join Service on ServiceEvent.Service_ID = Service.Service_ID
                WHERE 
                Song.Song_Type <> 'C'
                GROUP BY 
                Song.Song_ID, Song.Title, Song.Arranger, Song.Hymnbook_Num, Song.Song_Type
                
GO
