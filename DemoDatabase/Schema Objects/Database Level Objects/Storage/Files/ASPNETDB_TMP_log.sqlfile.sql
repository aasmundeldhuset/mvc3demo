﻿ALTER DATABASE [$(DatabaseName)]
    ADD LOG FILE (NAME = [ASPNETDB_TMP_log], FILENAME = '$(Path1)MVC3_log.LDF', FILEGROWTH = 10 %);

