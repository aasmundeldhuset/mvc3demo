﻿ALTER DATABASE [$(DatabaseName)]
    ADD FILE (NAME = [ASPNETDB_1cff9c2f862a49c88621830f029a9524_DAT], FILENAME = '$(Path2)aspnetdb.mdf', FILEGROWTH = 5120 KB) TO FILEGROUP [PRIMARY];

