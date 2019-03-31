Source is the same as 4-replicated-database

- slaves still use local volumes
- master db will be made highly available by leveraging cloudstore plugin

But this setup won't work because of filesystem incompatabilities.
