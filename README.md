# FBMAS
Facebook Marketplace Alerting System
---
Simple Facebook marketplace monitoring system. Based on user defined queries and an SMS alerting system.

This is only a proof of concept for learning. Running this is against the Facebook TOS because of the automated approach.

## Steps to run
1. Setup a postgres database server and have a database named `FBMAS`
2. Update appsettings.dev.json with correct connection string for database server
3. Run database schema scripts in `src/FBMAS.External/Data/Scripts`
4. Run `FBMAS.Runner`
